﻿using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using ShopifySharp.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopifySharp.Infrastructure;
using ShopifySharp.Lists;

namespace ShopifySharp
{
    /// <summary>
    /// A service for manipulating Shopify webhooks.
    /// </summary>
    public class WebhookService : ShopifyService
    {
        /// <summary>
        /// Creates a new instance of <see cref="WebhookService" />.
        /// </summary>
        /// <param name="myShopifyUrl">The shop's *.myshopify.com URL.</param>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public WebhookService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken) { }

        /// <summary>
        /// Gets a count of all of the shop's webhooks.
        /// </summary>
        /// <param name="filter">Options for filtering the result.</param>
        /// <returns>The count of all webhooks for the shop.</returns>
        public virtual async Task<int> CountAsync(WebhookCountFilter filter = null)
        {
            return await ExecuteGetAsync<int>("webhooks/count.json", "count", filter);
        }

        /// <summary>
        /// Gets a list of up to 250 of the shop's webhooks.
        /// </summary>
        /// <param name="filter">Options for filtering the list.</param>
        public virtual async Task<ListResult<Webhook>> ListAsync(ListFilter<Webhook> filter)
        {
            return await ExecuteGetListAsync("webhooks.json", "webhooks", filter);
        }

        /// <summary>
        /// Gets a list of up to 250 of the shop's webhooks.
        /// </summary>
        /// <param name="filter">Options for filtering the list.</param>
        public virtual async Task<ListResult<Webhook>> ListAsync(WebhookListFilter filter = null)
        {
            return await ListAsync(filter?.AsListFilter());
        }

        /// <summary>
        /// Retrieves the <see cref="Webhook"/> with the given id.
        /// </summary>
        /// <param name="webhookId">The id of the webhook to retrieve.</param>
        /// <param name="fields">A comma-separated list of fields to return.</param>
        /// <returns>The <see cref="Webhook"/>.</returns>
        public virtual async Task<Webhook> GetAsync(long webhookId, string fields = null)
        {
            return await ExecuteGetAsync<Webhook>($"webhooks/{webhookId}.json", "webhook", fields);
        }

        /// <summary>
        /// Creates a new <see cref="Webhook"/> on the store.
        /// </summary>
        /// <param name="webhook">A new <see cref="Webhook"/>. Id should be set to null.</param>
        /// <returns>The new <see cref="Webhook"/>.</returns>
        public virtual async Task<Webhook> CreateAsync(Webhook webhook)
        {
            return await ExecutePostAsync<Webhook>("webhooks.json", "webhook", new { webhook = webhook });
        }

        /// <summary>
        /// Updates the given <see cref="Webhook"/>.
        /// </summary>
        /// <param name="webhookId">Id of the object being updated.</param>
        /// <param name="webhook">The <see cref="Webhook"/> to update.</param>
        /// <returns>The updated <see cref="Webhook"/>.</returns>
        public virtual async Task<Webhook> UpdateAsync(long webhookId, Webhook webhook)
        {
            return await ExecutePutAsync<Webhook>($"webhooks/{webhookId}.json", "webhook", new { webhook = webhook });
        }

        /// <summary>
        /// Deletes the webhook with the given Id.
        /// </summary>
        /// <param name="webhookId">The order object's Id.</param>
        public virtual async Task DeleteAsync(long webhookId)
        {
            await ExecuteDeleteAsync($"webhooks/{webhookId}.json");
        }
    }
}
