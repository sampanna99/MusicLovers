using MusicLovers.Models;
using System.Collections.Generic;

namespace MusicLovers.ViewModels
{
    public class HomeViewModel
    {
        public bool ShowActions { get; set; }
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public string Heading { get; set; }
    }
}