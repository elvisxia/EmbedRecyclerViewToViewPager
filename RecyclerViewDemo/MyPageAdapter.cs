using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace RecyclerViewDemo
{
    public class MyPageAdapter : FragmentStatePagerAdapter
    {
        Android.Support.V4.App.FragmentManager _pageMgr;
        List<int> _pages;
        List<MyItem> _items;

        public MyPageAdapter(Android.Support.V4.App.FragmentManager mgr,List<int> pages,List<MyItem> items) : base(mgr)
        {
            _pageMgr = mgr;
            _pages = pages;
            _items = items;
        }


        public override int Count => _pages.Count;

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return new PageFragment(_pages[position], _items);
        }
        
    }
}