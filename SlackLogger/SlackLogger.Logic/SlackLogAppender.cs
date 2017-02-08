using System;
using log4net.Appender;
using log4net.Core;

namespace SlackLogger.Logic {
    public class SlackLogAppender : AppenderSkeleton {

        protected override void Append(LoggingEvent loggingEvent) {
            LogQueue.Enqueue(loggingEvent);
            Console.WriteLine("Message: " + loggingEvent.RenderedMessage);
        }
    }
}