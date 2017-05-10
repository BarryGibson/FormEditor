﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using FormEditor.NewsletterSubscription;
using Umbraco.Core.Models;

namespace FormEditor.Fields
{
	public class CampaignMonitorSubscriptionField : NewsletterSubscriptionField
	{
		public string NameField { get; set; }

		public override string Type
		{
			get { return "core.campaignmonitor"; }
		}

		protected override string ApiKeyAppSettingsKey
		{
			get { return "FormEditor.CampaignMonitor.ApiKey"; }
		}

		protected override string ListIdAppSettingsKey
		{
			get { return "FormEditor.CampaignMonitor.ListId"; }
		}

		protected override string ServiceName
		{
			get { return "Campaign Monitor"; }
		}

		protected override void HandleSubscription(MailAddress mailAddress, IEnumerable<Field> allCollectedValues, IPublishedContent content)
		{
			var valueFields = allCollectedValues.OfType<FieldWithValue>().ToArray();
			var nameField = valueFields.FirstOrDefault(f => f.Name.Equals(NameField, StringComparison.OrdinalIgnoreCase));

			var customFields = valueFields
				.Except(new[] {this, nameField}.Where(f => f != null))
				.ToDictionary(f => f.Name, f => f.SubmittedValue);

			var api = new CampaignMonitorApi();
			api.Subscribe(ListId, mailAddress, nameField != null ? nameField.SubmittedValue : null, customFields, ApiKey);
		}
	}
}
