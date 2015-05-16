using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace EnvironmentStatusViewer
{
    public class EnvironmentStatusViewModel : INotifyPropertyChanged
    {
        private static GradientStopCollection GoodColor = new GradientStopCollection(new GradientStop[] {
            new GradientStop((Color)ColorConverter.ConvertFromString("#FF11F311"), 0.5),
            new GradientStop((Color)ColorConverter.ConvertFromString("#FF128D12"), 1.0)
        });
        private static GradientStopCollection ProgressColor = new GradientStopCollection(new GradientStop[] {
            new GradientStop((Color)ColorConverter.ConvertFromString("#FFF3F311"), 0.5),
            new GradientStop((Color)ColorConverter.ConvertFromString("#FF8D8D12"), 1.0)
        });
        private static GradientStopCollection BrokenColor = new GradientStopCollection(new GradientStop[] {
            new GradientStop((Color)ColorConverter.ConvertFromString("#FFF31111"), 0.5),
            new GradientStop((Color)ColorConverter.ConvertFromString("#FF8D1212"), 1.0)
        });

        private string _devStatus;
        public string DevStatus
        {
            get { return _devStatus; }
            set
            {
                SetProperty(ref _devStatus, value);
                if (_devStatus.IndexOf("Broken", StringComparison.InvariantCultureIgnoreCase) >= 0) DevColor = BrokenColor;
                if (_devStatus.IndexOf("Progress", StringComparison.InvariantCultureIgnoreCase) >= 0) DevColor = ProgressColor;
                if (_devStatus.IndexOf("Good", StringComparison.InvariantCultureIgnoreCase) >= 0) DevColor = GoodColor;
            }
        }


        private GradientStopCollection _devColor = GoodColor;
        public GradientStopCollection DevColor
        {
            get { return _devColor; }
            private set
            {
                SetProperty(ref _devColor, value);
            }
        }

        private string _testStatus;
        public string TestStatus
        {
            get { return _testStatus; }
            set
            {
                SetProperty(ref _testStatus, value);
                if (_testStatus.IndexOf("Broken", StringComparison.InvariantCultureIgnoreCase) >= 0) TestColor = BrokenColor;
                if (_testStatus.IndexOf("Progress", StringComparison.InvariantCultureIgnoreCase) >= 0) TestColor = ProgressColor;
                if (_testStatus.IndexOf("Good", StringComparison.InvariantCultureIgnoreCase) >= 0) TestColor = GoodColor;
            }
        }

        private GradientStopCollection _testColor = GoodColor;
        public GradientStopCollection TestColor
        {
            get { return _testColor; }
            private set
            {
                SetProperty(ref _testColor, value);
            }
        }

        private string _stageStatus;
        public string StageStatus
        {
            get { return _stageStatus; }
            set
            {
                SetProperty(ref _stageStatus, value);
                if (_stageStatus.IndexOf("Broken", StringComparison.InvariantCultureIgnoreCase) >= 0) StageColor = BrokenColor;
                if (_stageStatus.IndexOf("Progress", StringComparison.InvariantCultureIgnoreCase) >= 0) StageColor = ProgressColor;
                if (_stageStatus.IndexOf("Good", StringComparison.InvariantCultureIgnoreCase) >= 0) StageColor = GoodColor;
            }
        }

        private GradientStopCollection _stageColor = GoodColor;
        public GradientStopCollection StageColor
        {
            get { return _stageColor; }
            private set { SetProperty(ref _stageColor, value); }
        }


        public void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (property != null && property.Equals(value))
                return;
            property = value;
            NotifyPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
