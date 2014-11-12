package com.example.mediaplayer;

import android.app.Activity;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.ServiceConnection;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.os.IBinder;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ImageButton;
import android.widget.Toast;

import com.example.mediaplayer.MusicService.LocalBinder;

public class MainActivity extends ActionBarActivity implements OnClickListener {
	Activity activity = this;
	ImageButton btnPlay, btnNext, btnPrevious;
	MusicService mService;
	boolean mBound = false;
	MediaPlayer musicPlayer;
	int currentSongIndex = 0;
	Integer[] songs = { R.raw.panther, R.raw.alpachino, R.raw.jingle };

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		btnPlay = (ImageButton) this.findViewById(R.id.btnPlay);
		btnPlay.setOnClickListener(this);
		btnNext = (ImageButton) this.findViewById(R.id.btnNext);
		btnNext.setOnClickListener(this);
		btnPrevious = (ImageButton) this.findViewById(R.id.btnPrevious);
		btnPrevious.setOnClickListener(this);

		Intent intent = new Intent(this, MusicService.class);
		bindService(intent, mConnection, Context.BIND_AUTO_CREATE);
	}

	private ServiceConnection mConnection = new ServiceConnection() {

		@Override
		public void onServiceConnected(ComponentName className, IBinder service) {
			// We've bound to LocalService, cast the IBinder and get
			// LocalService instance
			LocalBinder binder = (LocalBinder) service;
			mService = binder.getService();
			mBound = true;
			mService.loadSong(songs[0]);
		}

		@Override
		public void onServiceDisconnected(ComponentName arg0) {
			mBound = false;
		}
	};

	@Override
	public void onClick(View v) {
		if (mBound) {
			if (v.getId() == btnPlay.getId()) {
				mService.togglePlayPause();
				updatePlayButton();
			} else if (v.getId() == btnNext.getId()) {
				currentSongIndex = (currentSongIndex >= songs.length - 1) ? 0
						: currentSongIndex + 1;
				mService.loadSong(songs[currentSongIndex]);
				mService.playSong();
				updatePlayButton();
			} else if (v.getId() == btnPrevious.getId()) {
				currentSongIndex = (currentSongIndex == 0) ? songs.length - 1
						: currentSongIndex - 1;
				mService.loadSong(songs[currentSongIndex]);
				mService.playSong();
				updatePlayButton();
			}
		} else {
			Toast.makeText(this, "Application is loading", Toast.LENGTH_LONG);
		}
	}
	
	public void updatePlayButton(){
		if (mService.isPlaying()) {
			btnPlay.setImageResource(R.drawable.pause);
		} else if (!mService.isPlaying()) {
			btnPlay.setImageResource(R.drawable.play);
		}
	}
}
