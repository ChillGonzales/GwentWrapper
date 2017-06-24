using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GwentSite.AndroidUI
{
    public class ImageAdapter : BaseAdapter
    {
        Context context;
        List<System.IO.Stream> imgStreams;

        public ImageAdapter(Context c)
        {
            context = c;
        }

        public override int Count
        {
            get { return imgStreams.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }
        public void LoadImages(List<System.IO.Stream> streams)
        {
            imgStreams = streams;
        }
        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView imageView;

            if (convertView == null)
            {  // if it's not recycled, initialize some attributes
                imageView = new ImageView(context);
                imageView.LayoutParameters = new GridView.LayoutParams(85, 85);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                imageView.SetPadding(8, 8, 8, 8);
            }
            else
            {
                imageView = (ImageView)convertView;
            }
            //imageView.SetImageResource(thumbIds[position]);

            imageView.SetImageDrawable(new Android.Graphics.Drawables.BitmapDrawable(imgStreams[position]));
            return imageView;
        }
    }
}