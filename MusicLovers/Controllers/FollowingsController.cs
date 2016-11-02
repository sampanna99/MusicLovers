﻿using Microsoft.AspNet.Identity;
using MusicLovers.Dtos;
using MusicLovers.Models;
using System.Linq;
using System.Web.Http;

namespace MusicLovers.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        public ApplicationDbContext _context;
        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId))
            {
                return BadRequest("Following already exists");
            }
            var following = new Following { FollowerId = userId, FolloweeId = dto.FolloweeId };
            _context.Followings.Add(following);
            _context.SaveChanges();
            return Ok();
        }
    }
}
