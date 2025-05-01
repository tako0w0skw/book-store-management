using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI
{
    class ElipseControl : Component
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private Control _cntrl;
        private int _CornerRadius = 30;

        public Control TargetControl
        {
            get { return _cntrl; }
            set
            {
                _cntrl = value;
                if (_cntrl != null)
                {
                    _cntrl.SizeChanged += (sender, eventArgs) =>
                    {
                        if (_cntrl != null && !_cntrl.IsDisposed)
                        {
                            _cntrl.Region = Region.FromHrgn(
                                CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius)
                            );
                        }
                    };

                    // Áp dụng luôn khi gán control
                    _cntrl.Region = Region.FromHrgn(
                        CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius)
                    );
                }
            }
        }

        public int CornerRadius
        {
            get { return _CornerRadius; }
            set
            {
                _CornerRadius = value;
                if (_cntrl != null && !_cntrl.IsDisposed)
                {
                    _cntrl.Region = Region.FromHrgn(
                        CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius)
                    );
                }
            }
        }
    }
}
