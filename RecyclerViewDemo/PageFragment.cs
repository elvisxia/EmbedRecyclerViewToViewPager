using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace RecyclerViewDemo
{
    public class PageFragment : Android.Support.V4.App.Fragment
    {
        int _current;
        List<MyItem> _items;
        RecyclerView mRecyclerView;
        public PageFragment(int currentPage,List<MyItem> items)
        {
            _current = currentPage;
            _items = items;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
           View view=inflater.Inflate(Resource.Layout.PageFragment, container, false);
            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.mRecyclerView);
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(this.Activity));

            List<MyItem> filteredItems= _items.FindAll(m => m.Date == _current);
            MyRecyclerAdapter adapter = new MyRecyclerAdapter(this.Activity, filteredItems);
            mRecyclerView.SetAdapter(adapter);
            return view;
        }
    }
}