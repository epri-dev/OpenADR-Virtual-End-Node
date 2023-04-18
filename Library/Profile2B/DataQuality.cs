namespace Oadr.Library.Profile2B
{
    public class DataQuality
    {
        public static DataQuality NoQuality = new DataQuality("No Quality - No Value");

        public static DataQuality NoNewValue = new DataQuality("No New Value - Previous Value Used");

        public static DataQuality QualityBadNonSpecific = new DataQuality("Quality Bad - Non Specific");

        public static DataQuality QualityBadConfigurationError = new DataQuality("Quality Bad - Configuration Error");

        public static DataQuality QualityBadNotConnected = new DataQuality("Quality Bad - Not Connected");

        public static DataQuality QualityBadDeviceFailure = new DataQuality("Quality Bad - Device Failure");

        public static DataQuality QualityBadSensorFailure = new DataQuality("Quality Bad - Sensor Failure");

        public static DataQuality QualityBadLastKnownValue = new DataQuality("Quality Bad - Last Known Value");

        public static DataQuality QualityBadCommFailure = new DataQuality("Quality Bad - Comm Failure");

        public static DataQuality QualityBadOutOfService = new DataQuality("Quality Bad - Out of Service");

        public static DataQuality QualityUncertainNonSpecific = new DataQuality("Quality Uncertain - Non Specific");

        public static DataQuality QualityUncertainLastUsableValue = new DataQuality("Quality Uncertain - Last Usable Value");

        public static DataQuality QualityUncertainSensorNotAccurate = new DataQuality("Quality Uncertain - Sensor Not Accurate");

        public static DataQuality QualityUncertainEuUnitsExceeded = new DataQuality("Quality Uncertain - EU Units Exceeded");

        public static DataQuality QualityUncertainSubNormal = new DataQuality("Quality Uncertain - Sub Normal");

        public static DataQuality QualityGoodNonSpecific = new DataQuality("Quality Good - Non Specific");

        public static DataQuality QualityGoodLocalOverride = new DataQuality("Quality Good - Local Override");

        public static DataQuality QualityLimitFieldNot = new DataQuality("Quality Limit - Field/Not");

        public static DataQuality QualityLimitFieldLow = new DataQuality("Quality Limit - Field/Low");

        public static DataQuality QualityLimitFieldHigh = new DataQuality("Quality Limit - Field/High");

        public static DataQuality QualityLimitFieldConstant = new DataQuality("Quality Limit - Field/Constant");

        public string QualityType { get; }

        public DataQuality(string qualityType)
        {
            QualityType = qualityType;
        }
    }
}
