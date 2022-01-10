#pragma once
#include <string>
#include <unordered_map>

using Properties = std::unordered_map<std::string, std::string>;

inline std::string toJson(Properties &properties) {
	std::string json = "{";
	for (auto &p : properties) {
		json += "\"" + p.first + "\":\"" + p.second + "\",";
	}
	json.pop_back();
	json += "}";
	return json;
}