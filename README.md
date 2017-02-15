SlackLogger
======
SlackLogger is framework that can be integrated in your application to forward events to Slack.

Benefits of using SlackLogger:
- Supports large amounts of data events
- Asynchronous queue model, minimal impact on your application and its performance
- Flexible regular expression based filtering of event data
- Flexible templates to format your Slack messages the way you want
- Debouncing logic ensuring your events won't flood your Slack channel (coming soon)

### Integrating SlackLogger

Nuget packages coming soon.

OR

Reference source projects:
- SlackLogger.Client
- SlackLogger.Assets
- SlackLogger.Logic

Ensure SlackLogger.Assets is referenced in main application project as the current logic relies on the templates being copyed to the application bin output directory (this will be made more flexible soon).

### Configure message triggering

In SlackLogger.Assets project edit Messages.config.

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
Wrapping your domain objects in a view model, before adding them to SlackLogger might be worth considering if you require additional formatting logic.

Simple formatting can be done by writing: &lt;% CreatedDate:yyyy-MM-dd %&gt;.
Any formatting string can be used as supported by a normal String.Format in .NET and will likewise vary by data type.

### State of project

SlackLogger is still a work-in-progress and no official release has been made yet, but feel free to play around with it.

### Happy Slacking!
