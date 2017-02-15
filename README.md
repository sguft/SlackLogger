SlackLogger
======
SlackLogger is framework that can be integrated in your application to forward events to Slack.

Benefits of using SlackLogger:
- Supports large amounts of data events
- Asynchronous queue model, providing minimal impact on your application performance
- Flexible regular expression based filtering of event data
- Flexible templates to format your Slack messages the way you want for each event you wish to forward
- Debouncing logic ensuring your events won't flood your Slack channel (coming soon)

### Integrating SlackLogger

Nuget packages coming soon.

OR

Reference source projects:
- SlackLogger.Client
- SlackLogger.Assets
- SlackLogger.Logic

Ensure SlackLogger.Assets is referenced in main application project as the current logic relies on the templates being copyed to the application bin output directory (this will be made more flexible soon).

### Configure messages

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
