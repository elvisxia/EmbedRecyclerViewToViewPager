using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace RecyclerViewDemo
{
    public class MyRecyclerAdapter : RecyclerView.Adapter
    {
        List<MyItem> Items { get; set; }
        Context _context;
        public MyRecyclerAdapter(Context c, List<MyItem> list)
        {
            _context = c;
            Items = list;
        }
        public override int ItemCount => Items.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            (holder as MyViewHolder).Item.Text = Items[position].Value;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflator=LayoutInflater.FromContext(parent.Context);
            View view=inflator.Inflate(Resource.Layout.recyclerview_item,parent,false);
            MyViewHolder vh = new MyViewHolder(view);
            return vh;
        }
    }

    public class MyViewHolder : RecyclerView.ViewHolder
    {
        public MyViewHolder(View view) : base(view)
        {
            Item = view.FindViewById<TextView>(Resource.Id.tvItem);

        }
        public TextView Item { get; set; }
    }
}