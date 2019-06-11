ej.addCulture( "zh-CN", {
	name: "zh-CN",
	englishName: "Chinese (Simplified, China)",
	nativeName: "中文(中华人民共和国)",
	language: "zh-CHS",
	numberFormat: {
		pattern : ["-n"],
		",": ",",
		".": ".",
		groupSizes: [3],
		"NaN": "非数字",
		negativeInfinity: "负无穷大",
		positiveInfinity: "正无穷大",
		percent: {
			pattern: ["-n%","n%"],
			groupSizes: [3],
			",": ",",
			".": ".",
			symbol: '%'
		},
		currency: {
			pattern: ["$-n","$n"],
			groupSizes: [3],
			",": ",",
			".": ".",
			symbol: "¥"
		}
	},
	calendars: {
		standard: {
			firstDay: 1,
			days: {
				names: ["星期日","星期一","星期二","星期三","星期四","星期五","星期六"],
				namesAbbr: ["周日","周一","周二","周三","周四","周五","周六"],
				namesShort: ["日","一","二","三","四","五","六"]
			},
			months: {
				names: ["一月","二月","三月","四月","五月","六月","七月","八月","九月","十月","十一月","十二月",""],
				namesAbbr: ["1月","2月","3月","4月","5月","6月","7月","8月","9月","10月","11月","12月",""]
			},
			AM: ["上午","上午","上午"],
			PM: ["下午","下午","下午"],
			patterns: {
				d: "yyyy/M/d",
				D: "yyyy'年'M'月'd'日'",
				t: "H:mm",
				T: "H:mm:ss",
				f: "yyyy'年'M'月'd'日' H:mm",
				F: "yyyy'年'M'月'd'日' H:mm:ss",
				M: "M'月'd'日'",
				Y: "yyyy'年'M'月'"
			}
		}
	}
});