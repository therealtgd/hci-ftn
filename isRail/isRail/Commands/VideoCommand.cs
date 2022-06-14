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
                    new Video("/Videos/managerEditRideBaseShowcase.wmv").Show();
                    break;
                case "managerEditRideShowcase":
                    new Video("/Videos/managerEditRideShowcase.wmv").Show();
                    break;
                case "managerEditTrainShowcase":
                    new Video("/Videos/managerEditTrainShowcase.wmv").Show();
                    break;
                case "managerReportRideShowcase":
                    new Video("/Videos/managerReportRideShowcase.wmv").Show();
                    break;
                case "managerReportMonthShowcase":
                    new Video("/Videos/managerReportMonthShowcase.wmv").Show();
                    break;
                default:
                    break;
            }
        }
    }
}
