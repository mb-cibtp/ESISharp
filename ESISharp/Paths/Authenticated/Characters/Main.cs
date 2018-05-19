﻿using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Main : Public.Characters
    {
        private readonly Assets _Assets;
        private readonly Bookmarks _Bookmarks;
        private readonly Calendar _Calendar;
        private readonly Clones _Clones;
        private readonly Contacts _Contacts;
        private readonly Contracts _Contracts;
        private readonly FactionWarfare _FactionWarfare;

        public Assets Assets => _Assets;
        public Bookmarks Bookmarks => _Bookmarks;
        public Calendar Calendar => _Calendar;
        public Clones Clones => _Clones;
        public Contacts Contacts => _Contacts;
        public Contracts Contracts => _Contracts;
        public FactionWarfare FactionWarfare => _FactionWarfare;

        internal Main(EsiConnection esiconnection) : base(esiconnection)
        {
            _Assets = new Assets(esiconnection);
            _Bookmarks = new Bookmarks(esiconnection);
            _Calendar = new Calendar(esiconnection);
            _Clones = new Clones(esiconnection);
            _Contacts = new Contacts(esiconnection);
            _Contracts = new Contracts(esiconnection);
            _FactionWarfare = new FactionWarfare(esiconnection);
        }

        [Path("/characters/{character_id}/agents_research/", WebMethods.GET)]
        public EsiRequest GetAgentResearch(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "agents_research" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest GetBlueprints(int characterid)
            => GetBlueprints(characterid, 1);

        [Path("/characters/{character_id}/blueprints/", WebMethods.GET)]
        public EsiRequest GetBlueprints(int characterid, int page)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "blueprints" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["page"] = page
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest CalculateCspaCharge(int characterid, int charactertocheck)
            => CalculateCspaCharge(characterid, new int[] { charactertocheck });

        [Path("/characters/{character_id}/cspa/", WebMethods.POST)]
        public EsiRequest CalculateCspaCharge(int characterid, IEnumerable<int> characterstocheck)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "cspa" };
            var data = new EsiRequestData
            {
                Body = characterstocheck
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        [Path("/characters/{character_id}/fatigue/", WebMethods.GET)]
        public EsiRequest GetFatigue(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "fatigue" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/medals/", WebMethods.GET)]
        public EsiRequest GetMedals(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "medals" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/notifications/", WebMethods.GET)]
        public EsiRequest GetNotifications(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "notifications" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/notifications/contacts/", WebMethods.GET)]
        public EsiRequest GetNotificationsContacts(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "notifications", "contacts" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/roles/", WebMethods.GET)]
        public EsiRequest GetRoles(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "roles" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/standings/", WebMethods.GET)]
        public EsiRequest GetStandings(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "standings" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/stats/", WebMethods.GET)]
        public EsiRequest GetStats(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "stats" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/titles/", WebMethods.GET)]
        public EsiRequest GetTitles(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "titles" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}