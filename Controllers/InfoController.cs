﻿using System;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace App.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly HotelInfo _hotelinfo;

        public InfoController(IOptions<HotelInfo> hotelInfoWrapper)
        {
            _hotelinfo = hotelInfoWrapper.Value;
        }

        [HttpGet(Name =nameof(GetInfo))]
        [ProducesResponseType(200)]
        public ActionResult<HotelInfo> GetInfo()
        {
            _hotelinfo.Href = Url.Link(nameof(GetInfo),null);

            return _hotelinfo;
        }
    }
}