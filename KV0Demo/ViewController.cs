using System;

using AppKit;
using Foundation;

namespace KV0Demo
{
    public partial class ViewController : NSViewController
    {

        private Boolean _checkValue;
        [Export("CheckValue")]
        public Boolean CheckValue
        {
            get { return _checkValue; }
            set { WillChangeValue("CheckValue"); _checkValue = value; DidChangeValue("CheckValue"); }
        }


         
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.AddObserver(this, (NSString)"CheckValue", NSKeyValueObservingOptions.New, this.Handle);

            //Programtically update the value
            CheckValue = false;
        }



        public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
        {
            var msg = string.Format("Observer triggered for {0}", keyPath);
            Console.WriteLine( msg );

            LogField.StringValue = LogField.StringValue + "\n" +  msg;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
