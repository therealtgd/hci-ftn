using isRail.VideoView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class VideoCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            string video = parameter.ToString();
            switch (video)
            {
                case "managerEditRideBaseShowcase":
                    new Video(@"CekamoIliju").Show();
                    break;
                case "managerEditRideShowcase":
                    new Video(@"D:\Projects\C#\hci-ftn\isRail\isRail\Videos\managerEditRideShowcase.wmv").Show();
                    break;
                case "managerEditTrainShowcase":
                    new Video(@"D:\Projects\C#\hci-ftn\isRail\isRail\Videos\managerEditTrainShowcase.wmv").Show();
                    break;
                case "managerReportRideShowcase":
                    new Video(@"D:\Projects\C#\hci-ftn\isRail\isRail\Videos\managerReportRideShowcase.wmv").Show();
                    break;
                case "managerReportMonthShowcase":
                    new Video(@"D:\Projects\C#\hci-ftn\isRail\isRail\Videos\managerReportMonthShowcase.wmv").Show();
                    break;
                default:
                    break;
            }
        }
    }
}
