package com.example.asyncimagedownload;

import java.io.BufferedInputStream;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.URL;
import java.net.URLConnection;

import android.app.Activity;
import android.graphics.drawable.Drawable;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Environment;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ProgressBar;

public class MainActivity extends Activity {

    Button btnShowProgress;
    ImageView mImageView;
    ProgressBar mProgressBar;
    
    private static String file_url = "http://news.bbcimg.co.uk/media/images/74175000/jpg/_74175859_blue_flower.jpg";
 
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        
        mProgressBar = (ProgressBar) findViewById(R.id.progressBar1);
        mImageView = (ImageView) findViewById(R.id.imageView1);
        btnShowProgress = (Button) findViewById(R.id.btnProgressBar);
 
        btnShowProgress.setOnClickListener(new View.OnClickListener() {
 
            @Override
            public void onClick(View v) {
                new DownloadFileFromURL().execute(file_url);
            }
        });
    }
    
    class DownloadFileFromURL extends AsyncTask<String, String, String> {
 
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            mProgressBar.setVisibility(View.VISIBLE);
        }
     
        @Override
        protected String doInBackground(String... f_url) {
            int count;
            try {
                URL url = new URL(f_url[0]);
                URLConnection conection = url.openConnection();
                conection.connect();
                int lenghtOfFile = conection.getContentLength();
     
                InputStream input = new BufferedInputStream(url.openStream(), 8192);
     
                OutputStream output = new FileOutputStream(Environment.DIRECTORY_DOWNLOADS + "/downloadedfile.jpg");
     
                byte data[] = new byte[1024];
     
                long total = 0;
     
                while ((count = input.read(data)) != -1) {
                    total += count;
                    publishProgress(""+(int)((total*100)/lenghtOfFile));
                    output.write(data, 0, count);
                }
     
                output.flush();
     
                output.close();
                input.close();
     
            } catch (Exception e) {
                Log.e("Error: ", e.getMessage());
            }
     
            return null;
        }
     
        protected void onProgressUpdate(String... progress) {
        	mProgressBar.setProgress(Integer.parseInt(progress[0]));
       }
     
        @Override
        protected void onPostExecute(String file_url) {
        	mProgressBar.setVisibility(ProgressBar.INVISIBLE);
            String imagePath = Environment.getExternalStorageDirectory().toString() + "/downloadedfile.jpg";
            
            mImageView.setImageDrawable(Drawable.createFromPath(imagePath));
        }
     
    }
}
