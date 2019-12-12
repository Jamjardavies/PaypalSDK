using AppKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace PaypalTest.MacOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        private NSWindow m_window = null;

        public override NSWindow MainWindow => m_window;

        public AppDelegate()
        {
            NSWindowStyle style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            CoreGraphics.CGRect rect = new CoreGraphics.CGRect(200, 200, 800, 600);
            m_window = new NSWindow(rect, style, NSBackingStore.Buffered, false)
            {
                Title = ""
            };
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            LoadApplication(new App());
            base.DidFinishLaunching(notification);
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
