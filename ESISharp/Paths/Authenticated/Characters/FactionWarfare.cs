﻿using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class FactionWarfare : ApiPath
    {
        internal FactionWarfare(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/fw/stats/", WebMethods.GET)]
        public EsiRequest GetOverview(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "fw", "stats" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}