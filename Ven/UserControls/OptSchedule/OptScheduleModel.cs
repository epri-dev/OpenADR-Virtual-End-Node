using Oadr.Library;
using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;

namespace Oadr.Ven.UserControls.OptSchedule
{
    public class OptScheduleModel
    {
        private readonly Dictionary<string, List<OptStateButtonState>> _buttonStates = new Dictionary<string, List<OptStateButtonState>>();

        public string Name { get; set; }

        public CreateOpt CreateOpt { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public string OptInReason { get; set; }

        public string OptOutReason { get; set; }

        public string OptId { get; private set; }

        public string OptInId => $"{OptId}-IN";

        public string OptOutId => $"{OptId}-OUT";

        public bool OptInRegistered { get; set; } = false;

        public bool OptOutRegistered { get; set; } = false;

        public OptScheduleModel()
        {
            OptId = RandomHex.Instance().GenerateRandomHex(10);
        }

        private static OptReasonEnumeratedType ConvertOptReasonString(string optReason)
        {
            if (optReason == OptReasonEnumeratedType.economic.ToString())
            {
                return OptReasonEnumeratedType.economic;
            }

            if (optReason == OptReasonEnumeratedType.emergency.ToString())
            {
                return OptReasonEnumeratedType.emergency;
            }

            if (optReason == OptReasonEnumeratedType.mustRun.ToString())
            {
                return OptReasonEnumeratedType.mustRun;
            }

            if (optReason == OptReasonEnumeratedType.notParticipating.ToString())
            {
                return OptReasonEnumeratedType.notParticipating;
            }

            if (optReason == OptReasonEnumeratedType.outageRunStatus.ToString())
            {
                return OptReasonEnumeratedType.outageRunStatus;
            }

            if (optReason == OptReasonEnumeratedType.overrideStatus.ToString())
            {
                return OptReasonEnumeratedType.overrideStatus;
            }

            if (optReason == OptReasonEnumeratedType.participating.ToString())
            {
                return OptReasonEnumeratedType.participating;
            }

            if (optReason == OptReasonEnumeratedType.xschedule.ToString())
            {
                return OptReasonEnumeratedType.xschedule;
            }

            return OptReasonEnumeratedType.economic;
        }
        
        public OptReasonEnumeratedType GetOptInReasonEnum()
        {
            return ConvertOptReasonString(OptInReason);
        }
        
        public OptReasonEnumeratedType GetOptOutReasonEnum()
        {
            return ConvertOptReasonString(OptOutReason);
        }
        
        public void SetButtonState(string weekday, int hour, OptStateButtonState buttonState)
        {
            if (!_buttonStates.ContainsKey(weekday))
            {
                _buttonStates.Add(weekday, new List<OptStateButtonState>());
            }

            if (_buttonStates[weekday].Count <= hour)
            {
                _buttonStates[weekday].Add(buttonState);
            }
            else
            {
                _buttonStates[weekday][hour] = buttonState;
            }
        }
        
        public OptStateButtonState GetButtonState(string weekday, int hour)
        {
            return _buttonStates[weekday][hour];
        }
        
        public Library.Profile2B.OptSchedule GetOptSchedule(Library.Profile2B.OptSchedule optSchedule, OptStateButtonState buttonState)
        {
            var current = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day);
            var end = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day);
            var scheduleDuration = 0;
            var scheduleStartTime = DateTime.Now;

            while (current <= end)
            {
                var hourButtonState = _buttonStates[current.DayOfWeek.ToString()];
                for (var hour = 0; hour < 24; hour++)
                {
                    if (hourButtonState[hour] == buttonState)
                    {
                        scheduleDuration++;
                        if (scheduleDuration == 1)
                        {
                            scheduleStartTime = current.AddHours(hour);
                        }
                    }
                    else
                    {
                        if (scheduleDuration > 0)
                        {
                            optSchedule.AddOptSchedule(scheduleStartTime.ToUniversalTime(), scheduleDuration);
                            scheduleDuration = 0;
                        }
                    }                    
                }
                current = current.AddDays(1);
            }

            if (optSchedule.Schedule.Count == 0)
            {
                return null;
            }
            return optSchedule;
        }
        
        public Library.Profile2B.OptSchedule GetOptInSchedule()
        {
            var optSchedule = new Library.Profile2B.OptSchedule
            {
                OptReason = ConvertOptReasonString(OptInReason),
                OptType = OptTypeType.optIn,
                OptId = OptInId
            };
            return GetOptSchedule(optSchedule, OptStateButtonState.OptIn);
        }
        
        public Library.Profile2B.OptSchedule GetOptOutSchedule()
        {
            var optSchedule = new Library.Profile2B.OptSchedule
            {
                OptReason = ConvertOptReasonString(OptOutReason),
                OptType = OptTypeType.optOut,
                OptId = OptOutId
            };
            return GetOptSchedule(optSchedule, OptStateButtonState.OptOut);
        }
    }
}
