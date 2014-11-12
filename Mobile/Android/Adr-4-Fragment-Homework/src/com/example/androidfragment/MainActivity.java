package com.example.androidfragment;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.ActionBarActivity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.LinearLayout;

public class MainActivity extends ActionBarActivity {
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		if (savedInstanceState == null) {
			getSupportFragmentManager().beginTransaction()
					.add(R.id.container, new PlaceholderFragment()).commit();
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

	public static class PlaceholderFragment extends Fragment implements
			OnClickListener {
		LinearLayout ll1, ll2, ll3, ll4;

		public PlaceholderFragment() {
		}

		@Override
		public View onCreateView(LayoutInflater inflater, ViewGroup container,
				Bundle savedInstanceState) {
			View rootView = inflater.inflate(R.layout.fragment_main, container,
					false);
			this.ll1 = (LinearLayout) rootView.findViewById(R.id.product1);
			this.ll2 = (LinearLayout) rootView.findViewById(R.id.product2);
			this.ll3 = (LinearLayout) rootView.findViewById(R.id.product3);
			this.ll4 = (LinearLayout) rootView.findViewById(R.id.product4);

			this.ll1.setOnClickListener(this);
			this.ll2.setOnClickListener(this);
			this.ll3.setOnClickListener(this);
			this.ll4.setOnClickListener(this);
			return rootView;
		}

		@Override
		public void onClick(View v) {
			Bundle args = new Bundle();
			if (v.getId() == R.id.product1) {
				args.putString("product", "Product 1");
				args.putString("category", "First category");
				this.changeFragment(args);
			} else if (v.getId() == R.id.product2) {
				args.putString("product", "Product 2");
				args.putString("category", "Second category");
				this.changeFragment(args);
			} else if (v.getId() == R.id.product3) {
				args.putString("product", "Product 3");
				args.putString("category", "Third category");
				this.changeFragment(args);
			} else if (v.getId() == R.id.product4) {
				args.putString("product", "Product 4");
				args.putString("category", "Fourth category");
				this.changeFragment(args);
			}
		}

		private void changeFragment(Bundle args) {
			ProductActivity newFragment = new ProductActivity();
			newFragment.setArguments(args);

			FragmentTransaction transaction = getFragmentManager()
					.beginTransaction();
			transaction.replace(R.id.container, newFragment);
			transaction.addToBackStack(null);

			transaction.commit();
		}
	}
}
