using System;
using Xamarin.Forms;

namespace CoronaNews.CustomControls
{
    public class CustomImage : Image
    {
        public event EventHandler ImageClicked;

        public CustomImage()
        {
            var tgr = new TapGestureRecognizer {NumberOfTapsRequired = 1};
            tgr.Tapped += ImageOn_Clicked;
            this.GestureRecognizers.Add(tgr);
        }

        protected virtual void ImageOn_Clicked(object sender , EventArgs e)
        {
            ImageClicked?.Invoke(sender,e);
        }
    }
}