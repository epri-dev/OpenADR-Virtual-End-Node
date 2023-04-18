using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using System;

namespace Oadr.Library
{
    /// <summary>
    /// Static helper functions for creating frequently used OADR objects.
    /// </summary>
    public class OadrObjectFactory
    {
        public static oadrLoadControlStateTypeType CreateLoadControlStateType(float min, float max, float current, float normal)
        {
            return new oadrLoadControlStateTypeType
            {
                oadrMin = min,
                oadrMax = max,
                oadrCurrent = current,
                oadrNormal = normal
            };
        }

        public static IntervalType CreateIntervalType(DateTime startUtc, oadrReportPayloadType reportPayload, int duration = -1, DurationModifier durationModifier = null)
        {
            var interval = new IntervalType
            {
                dtstart = new dtstart
                {
                    datetime = startUtc
                }
            };

            if (duration != -1 && durationModifier != null)
            {
                interval.duration = new DurationPropType
                {
                    duration = $"PT{duration}{durationModifier.Value}"
                };
            }

            interval.streamPayloadBase = new StreamPayloadBaseType[1];
            interval.streamPayloadBase[0] = reportPayload;
            return interval;
        }

        public static IntervalType CreateIntervalType(DateTime startUtc, int duration = -1, DurationModifier durationModifier = null)
        {
            var interval = new IntervalType
            {
                dtstart = new dtstart
                {
                    datetime = startUtc
                }
            };
            if (duration != -1 && durationModifier != null)
            {
                interval.duration = new DurationPropType
                {
                    duration = $"PT{duration}{durationModifier.Value}"
                };
            }
            return interval;
        }
    }
}
