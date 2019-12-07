﻿using System;
using System.Collections.Generic;
using System.Text;
using AdvertApi.Models.Messages;

namespace WebAdvert.ElasticSearch
{
    public static class MappingHelper
    {
        public static AdvertType Map(AdvertConfirmedMessage message)
        {
            var doc = new AdvertType
            {
                Id = message.Id,
                Title = message.Title,
                CreationDateTime = DateTime.UtcNow
            };
            return doc;
        }
    }
}
