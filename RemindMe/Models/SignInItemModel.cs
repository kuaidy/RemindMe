using RemindMe.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace RemindMe.Models
{
    public class SignInItemModel : NotifactionObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.RaisePropertyChange("Name");
            }
        }
        private string _desc;
        public string Desc
        {
            get
            {
                return _desc;
            }
            set
            {
                _desc = value;
                this.RaisePropertyChange("Desc");
            }
        }
        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                this.RaisePropertyChange("ImageUrl");
            }
        }
        private ImageSource _image;
        public ImageSource Image
        {
            get { return _image; }
            set
            {
                _image = value;
                this.RaisePropertyChange("Image");
            }
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                this.RaisePropertyChange("URL");
            }
        }
        private string _method;
        public string Method
        {
            get
            {
                return _method;
            }
            set
            {
                _method = value;
                this.RaisePropertyChange("Method");
            }
        }
        private int _Hour;
        public int Hour
        {
            get
            {
                return _Hour;
            }
            set
            {
                _Hour = value;
                this.RaisePropertyChange("Hour");
            }
        }

        private int _Minute;
        public int Minute
        {
            get
            {
                return _Minute;
            }
            set
            {
                _Minute = value;
                this.RaisePropertyChange("Minute");
            }
        }

        private int _Second;
        public int Second
        {
            get
            {
                return _Second;
            }
            set
            {
                _Second = value;
                this.RaisePropertyChange("Second");
            }
        }

        private string _time;
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                this.RaisePropertyChange("Time");
            }
        }
        private string _signTime;
        public string SignTime
        {
            get
            {
                return _signTime;
            }
            set
            {
                _signTime = value;
                this.RaisePropertyChange("SignTime");
            }
        }
        private string _status = "签到";
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                this.RaisePropertyChange("Status");
            }
        }
    }
}
