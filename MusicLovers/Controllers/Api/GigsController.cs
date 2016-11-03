using Microsoft.AspNet.Identity;
using MusicLovers.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace MusicLovers.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Include(g => g.Attendances.Select(a => a.Attendee)).Single(g => g.Id == id && g.ArtistId == userId);
            if (gig.IsCanceled)
            {
                return NotFound();
            }
            gig.IsCanceled = true;
            var notification = new Notification(NotificationType.GigCancelled, gig);

            //var attendees = _context.Attendances.Where(a => a.GigId == gig.Id).Select(a => a.Attendee).ToList();

            foreach (var attendee in gig.Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
