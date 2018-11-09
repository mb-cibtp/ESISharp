﻿using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Opportunities : ApiPath
    {
        internal Opportunities(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/opportunities/", WebMethods.GET)]
        public EsiRequest GetCompleted(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "opportunities" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
