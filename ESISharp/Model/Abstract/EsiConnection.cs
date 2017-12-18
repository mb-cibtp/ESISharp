﻿using ESISharp.Enumeration;
using ESISharp.Web;
using Polly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ESISharp.Model.Abstract
{
    public abstract class EsiConnection
    {
        internal DataSource DataSource = DataSource.Tranquility;
        internal ResponseType ResponseType = ResponseType.Json;
        internal Route Route = Route.Latest;

        internal IAsyncPolicy<HttpResponseMessage> HttpResiliencePolicy;
        internal HttpClient QueryClient;
        internal string UserAgent = @"ESISharp (github.com/wranders/ESISharp)";

        internal Access Access;

        protected EsiConnection()
        {
            var HttpClientHandler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            QueryClient = new HttpClient(HttpClientHandler);
            QueryClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            QueryClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            QueryClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

            SetRetryStrategy(new TimeSpan[] { });
        }

        public void SetDataSource(DataSource datasource) => DataSource = datasource;

        public void SetResponseType(ResponseType responsetype) => ResponseType = responsetype;

        public void SetHttpPolicy(IAsyncPolicy<HttpResponseMessage> policy) => HttpResiliencePolicy = policy;

        public void SetRetryStrategy(IEnumerable<TimeSpan> delays)
        {
            HttpResiliencePolicy = Policy<HttpResponseMessage>
                .Handle<Exception>()
                .OrResult(r =>
                       r.StatusCode == HttpStatusCode.InternalServerError
                    || r.StatusCode == HttpStatusCode.BadGateway
                    || r.StatusCode == HttpStatusCode.ServiceUnavailable
                    || r.StatusCode == HttpStatusCode.GatewayTimeout)
                .WaitAndRetryAsync(delays);
        }

        public void SetRoute(Route route) => Route = route;

        public void SetTimeout(TimeSpan timespan) => QueryClient.Timeout = timespan;

        public void SetUserAgent(string useragent)
        {
            UserAgent = useragent;
            QueryClient.DefaultRequestHeaders.UserAgent.Clear();
            QueryClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        }
    }
}