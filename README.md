SlackLogger
======
SlackLogger is a framework that can be integrated in your application to forward events to Slack.

Benefits of using SlackLogger:
- Asynchronous queueing model, minimal impact on your application and its performance
- Flexible regular expression based filtering of event data
- Flexible templates to format your Slack messages the way you want
- Debouncing logic ensuring your events won't flood your Slack channel (coming soon)

### Integrating SlackLogger

Nuget packages coming soon.

OR

Reference source projects:
- SlackLogger.Core

To enable SlackLogger a configuration is needed with some basic info and the background worker "SlackProcessor" needs to be started:
```cs
SlackConfig config = new SlackConfig();
config.WebhookUrl = "https://hooks.slack.com/services/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"; // your Slack Webhook Url
config.TemplateRootFolder = "./Configuration"; // Directory relative to output directory where templates and messages.config is stored
SlackProcessor.Start(config); // Start the event processing loop
```

Now events are ready to be added:

```cs
SlackProcessor.Enqueue(new { Foo = "Bar" });
```

### Configure message triggering

Create an XML file in your TemplateRootFolder called: Messages.config.

All incoming events will be evaluated against the rules specified in this configuration. If a rule matches a message will be sent to Slack using the associated Template.

For instance:

```xml
<include templateFile="Exception.template.json">
  <pattern property="LogLevel">error</pattern>
  <pattern property="Message">^Exception:.+</pattern>
</include>
```

Will trigger a message to Slack using the template Exception.template.json whenever an event object with the property LogLevel is set to error and the property Message contains a line that starts with "Exception:".

Please note: Regular expression matching is set to multiline, meaning ^ and $ will match the beginning and end of each line, not the entire message.

Also note: Only the first &lt;include&gt; defined where all expressions matches will trigger a slack message, any other matching &lt;include&gt; elements will be ignored.

### Template formatting

Templates are very flexible as they contain the full json payload sent to Slack. This means you can use any formatting and message feature available in [the Slack Api](https://api.slack.com/docs/messages).

You can inject custom data from your event data objects using the following syntax: &lt;% Property %&gt;.

Here is what a basic exception template could look like for a typical log event:

```json
{
  "attachments": [
    {
      "fallback": "PROD ```<% Exception %>```",
      "color": "#ff0000",
      "pretext": "",
      "author_name": "PROD",
      "text": "```<% Exception %>```",
      "ts": "<% TimestampLocal %>",
      "mrkdwn_in": [ "text", "pretext" ]
    }
  ]
}
```

Currently only properties are supported. 

Simple formatting can be done by writing: &lt;% CreatedDate:yyyy-MM-dd %&gt;.
Any formatting string can be used as supported by a normal String.Format in .NET and will likewise vary by data type.

Wrapping your domain objects in a view model, before adding them to SlackLogger might be worth considering if you require more advanced  formatting logic.

Please Note: Template filename must end with: .template.json to be recognized.

### State of project

SlackLogger is still a work-in-progress and no official release has been made yet, but feel free to play around with it.

### Happy Slacking!
