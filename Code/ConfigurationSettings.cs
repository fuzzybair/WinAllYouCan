using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WinAllYouCan.Code
{
	class ConfigurationSettings
	{
		private static Configuration m_Config;

		private static Configuration Config
		{
			get
			{
				if (m_Config == null)
				{
					m_Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				}
				return m_Config;
			}

			set
			{
				m_Config = value;
			}
		}
		private static AppSettingsSection m_AppSettings;

		private static AppSettingsSection AppSettings
		{
			get
			{
				if (m_AppSettings == null)
				{
					m_AppSettings = Config.GetSection("appSettings") as AppSettingsSection;
				}
				return m_AppSettings;
			}

			set
			{
				m_AppSettings = value;
			}
		}

		public static T Get<T>(Setting setting)
		{
			string settingValue = AppSettings.Settings[setting.ToString()].Value;
			return (T)Convert.ChangeType(settingValue, typeof(T));
		}
	}
}
