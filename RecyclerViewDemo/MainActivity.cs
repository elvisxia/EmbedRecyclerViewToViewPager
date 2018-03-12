using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Support.V4.View;
using System;
using System.Linq;
using Android.Support.V7.App;

namespace RecyclerViewDemo
{
    [Activity(Label = "RecyclerViewDemo", MainLauncher = true,Theme ="@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        ViewPager mViewPager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mViewPager = FindViewById<ViewPager>(Resource.Id.mViewPager);
            List<MyItem> items = InitDataSource();
            List<int> groups = new List<int> { 0,1, 2, 3, 4, 5, 6, 7, 8, 9 };
            PagerAdapter adapter = new MyPageAdapter(SupportFragmentManager, groups,items);
            mViewPager.Adapter = adapter;
        }

        private List<MyItem> InitDataSource()
        {
            List<MyItem> items = new List<MyItem>();
            int currentDate = 0;
            int group=0;
            for (int i = 0; i < 100; i++)
            {
                if (group != (i % 10))
                {
                    group = i % 10;
                    currentDate = group;
                }
                items.Add(new MyItem {
                    Value="Item: "+i+"\t Item Group: "+ group,
                    Date=currentDate
                });
            }

            return items;
        }
    }
}

