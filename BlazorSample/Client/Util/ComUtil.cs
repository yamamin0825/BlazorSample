using System.Net;
using System.Text.Json;
using BlazorSample.Client.Data;

namespace BlazorSample.Client.Util
{
    static public class ComUtil
    {
        enum TREE_POSS
        {
            NONE,
            TOP,
            TOP_END,
            
            CENTER_TOP,
            CENTER_TOP_CODE,
            CENTER_TOP_CODE_END,
            CENTER_AREA_DATA_START,

            OFFICE_TOP,
            OFFICE_TOP_CODE,
            OFFICE_TOP_CODE_END,
            OFFICE_AREA_DATA_START,

            CLASS10S_TOP,
            CLASS10S_TOP_CODE,
            CLASS10S_TOP_CODE_END,
            CLASS10S_AREA_DATA_START,

            CLASS15S_TOP,
            CLASS15S_TOP_CODE,
            CLASS15S_TOP_CODE_END,
            CLASS15S_AREA_DATA_START,

            CLASS20S_TOP,
            CLASS20S_TOP_CODE,
            CLASS20S_TOP_CODE_END,
            CLASS20S_AREA_DATA_START
        }

        static public async Task<string> GetJsonStr(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    string response = await httpClient.GetStringAsync(uri);
                    return response;
                }
                catch(Exception ex)
                {
                    return string.Empty;
                }
            }
        }

        static public JsonDataArea GetJsonDataArea(string jsonStr)
        {
            TREE_POSS treePoss = 0;
            JsonDataArea jsonArea = new JsonDataArea();

            string code = string.Empty;
            string areaDataStr = string.Empty;

            for(int i = 0; i < jsonStr.Length; i++)
            {
                char c = jsonStr[i];
                if (treePoss == TREE_POSS.NONE && c == '"')
                {
                    treePoss = TREE_POSS.TOP;
                }
                else if (treePoss == TREE_POSS.TOP && c == '"')
                {
                    if (code == "centers")
                    {
                        treePoss = TREE_POSS.CENTER_TOP;
                    }
                    else if (code == "offices")
                    {
                        treePoss = TREE_POSS.OFFICE_TOP;
                    }
                    else if (code == "class10s")
                    {
                        treePoss = TREE_POSS.CLASS10S_TOP;
                    }
                    else if (code == "class15s")
                    {
                        treePoss = TREE_POSS.CLASS15S_TOP;
                    }
                    else if (code == "class20s")
                    {
                        treePoss = TREE_POSS.CLASS20S_TOP;
                    }
                    code = string.Empty;
                }
                else if (treePoss == TREE_POSS.TOP)
                {
                    code += c;
                }

                else if (treePoss == TREE_POSS.CENTER_TOP && c == '"')
                {
                    treePoss = TREE_POSS.CENTER_TOP_CODE;
                }
                else if (treePoss == TREE_POSS.CENTER_TOP_CODE && c == '"')
                {
                    treePoss = TREE_POSS.CENTER_TOP_CODE_END;
                }
                else if (treePoss == TREE_POSS.CENTER_TOP_CODE)
                {
                    code += c;
                }

                else if (treePoss == TREE_POSS.CENTER_TOP_CODE_END && c == '{')
                {
                    treePoss = TREE_POSS.CENTER_AREA_DATA_START;
                    areaDataStr += c;
                }
                else if (treePoss == TREE_POSS.CENTER_TOP && c == '}')
                {
                    treePoss = TREE_POSS.NONE;
                }
                else if (treePoss == TREE_POSS.CENTER_AREA_DATA_START && c == '}')
                {
                    treePoss = TREE_POSS.CENTER_TOP;
                    areaDataStr += c;

                    var areaData = JsonSerializer.Deserialize<CenterAreaData>(areaDataStr);
                    jsonArea.centers.areas.Add(code, areaData);

                    code = string.Empty;
                    areaDataStr = string.Empty;
                }
                else if (treePoss == TREE_POSS.CENTER_AREA_DATA_START)
                {
                    areaDataStr += c;
                }

                else if (treePoss == TREE_POSS.OFFICE_TOP && c == '"')
                {
                    treePoss = TREE_POSS.OFFICE_TOP_CODE;
                }
                else if (treePoss == TREE_POSS.OFFICE_TOP_CODE && c == '"')
                {
                    treePoss = TREE_POSS.OFFICE_TOP_CODE_END;
                }
                else if (treePoss == TREE_POSS.OFFICE_TOP_CODE)
                {
                    code += c;
                }

                else if (treePoss == TREE_POSS.OFFICE_TOP_CODE_END && c == '{')
                {
                    treePoss = TREE_POSS.OFFICE_AREA_DATA_START;
                    areaDataStr += c;
                }
                else if (treePoss == TREE_POSS.OFFICE_TOP && c == '}')
                {
                    treePoss = TREE_POSS.NONE;
                }
                else if (treePoss == TREE_POSS.OFFICE_AREA_DATA_START && c == '}')
                {
                    treePoss = TREE_POSS.OFFICE_TOP;
                    areaDataStr += c;

                    var areaData = JsonSerializer.Deserialize<OfficeAreaData>(areaDataStr);
                    jsonArea.offices.areas.Add(code, areaData);

                    code = string.Empty;
                    areaDataStr = string.Empty;
                }
                else if (treePoss == TREE_POSS.OFFICE_AREA_DATA_START)
                {
                    areaDataStr += c;
                }

                else if (treePoss == TREE_POSS.CLASS10S_TOP && c == '"')
                {
                    treePoss = TREE_POSS.CLASS10S_TOP_CODE;
                }
                else if (treePoss == TREE_POSS.CLASS10S_TOP_CODE && c == '"')
                {
                    treePoss = TREE_POSS.CLASS10S_TOP_CODE_END;
                }
                else if (treePoss == TREE_POSS.CLASS10S_TOP_CODE)
                {
                    code += c;
                }

                else if (treePoss == TREE_POSS.CLASS10S_TOP_CODE_END && c == '{')
                {
                    treePoss = TREE_POSS.CLASS10S_AREA_DATA_START;
                    areaDataStr += c;
                }
                else if (treePoss == TREE_POSS.CLASS10S_TOP && c == '}')
                {
                    treePoss = TREE_POSS.NONE;
                }
                else if (treePoss == TREE_POSS.CLASS10S_AREA_DATA_START && c == '}')
                {
                    treePoss = TREE_POSS.CLASS10S_TOP;
                    areaDataStr += c;

                    var areaData = JsonSerializer.Deserialize<AreaData>(areaDataStr);
                    jsonArea.class10s.areas.Add(code, areaData);

                    code = string.Empty;
                    areaDataStr = string.Empty;
                }
                else if (treePoss == TREE_POSS.CLASS10S_AREA_DATA_START)
                {
                    areaDataStr += c;
                }

                else if (treePoss == TREE_POSS.CLASS15S_TOP && c == '"')
                {
                    treePoss = TREE_POSS.CLASS15S_TOP_CODE;
                }
                else if (treePoss == TREE_POSS.CLASS15S_TOP_CODE && c == '"')
                {
                    treePoss = TREE_POSS.CLASS15S_TOP_CODE_END;
                }
                else if (treePoss == TREE_POSS.CLASS15S_TOP_CODE)
                {
                    code += c;
                }

                else if (treePoss == TREE_POSS.CLASS15S_TOP_CODE_END && c == '{')
                {
                    treePoss = TREE_POSS.CLASS15S_AREA_DATA_START;
                    areaDataStr += c;
                }
                else if (treePoss == TREE_POSS.CLASS15S_TOP && c == '}')
                {
                    treePoss = TREE_POSS.NONE;
                }
                else if (treePoss == TREE_POSS.CLASS15S_AREA_DATA_START && c == '}')
                {
                    treePoss = TREE_POSS.CLASS15S_TOP;
                    areaDataStr += c;

                    var areaData = JsonSerializer.Deserialize<AreaData>(areaDataStr);
                    jsonArea.class15s.areas.Add(code, areaData);

                    code = string.Empty;
                    areaDataStr = string.Empty;
                }
                else if (treePoss == TREE_POSS.CLASS15S_AREA_DATA_START)
                {
                    areaDataStr += c;
                }

                else if (treePoss == TREE_POSS.CLASS20S_TOP && c == '"')
                {
                    treePoss = TREE_POSS.CLASS20S_TOP_CODE;
                }
                else if (treePoss == TREE_POSS.CLASS20S_TOP_CODE && c == '"')
                {
                    treePoss = TREE_POSS.CLASS20S_TOP_CODE_END;
                }
                else if (treePoss == TREE_POSS.CLASS20S_TOP_CODE)
                {
                    code += c;
                }

                else if (treePoss == TREE_POSS.CLASS20S_TOP_CODE_END && c == '{')
                {
                    treePoss = TREE_POSS.CLASS20S_AREA_DATA_START;
                    areaDataStr += c;
                }
                else if (treePoss == TREE_POSS.CLASS20S_TOP && c == '}')
                {
                    treePoss = TREE_POSS.NONE;
                }
                else if (treePoss == TREE_POSS.CLASS20S_AREA_DATA_START && c == '}')
                {
                    treePoss = TREE_POSS.CLASS20S_TOP;
                    areaDataStr += c;

                    var areaData = JsonSerializer.Deserialize<AreaData2>(areaDataStr);
                    jsonArea.class20s.areas.Add(code, areaData);

                    code = string.Empty;
                    areaDataStr = string.Empty;
                }
                else if (treePoss == TREE_POSS.CLASS20S_AREA_DATA_START)
                {
                    areaDataStr += c;
                }
            }
            return jsonArea;
        }

        static public JsonDataForecast GetJsonDataForecast(string jsonStr)
        {
            JsonDataForecast jsonData = new JsonDataForecast();

            int depth = 0;
            string line = string.Empty;

            for (int i = 0; i < jsonStr.Length; i++)
            {
                char c = jsonStr[i];

                if (c == '{')
                {
                    depth++;
                }

                if (depth > 0)
                    line += c;

                if (c == '}')
                {
                    depth--;
                    if (depth == 0)
                    {
                        var rootobject = JsonSerializer.Deserialize<Rootobject>(line);
                        jsonData.rootobjects.Add(rootobject);
                        line = string.Empty;
                    }
                }
            }

            return jsonData;
        }

        static public Dictionary<string, string[]> GetWeatherCode(string jsonStr)
        {
            Dictionary<string, string[]> weatherCodePairs = new Dictionary<string, string[]>();

            bool isKey = false;
            bool isValue = false;

            string key = string.Empty;
            string value = string.Empty;

            for (int i = 0; i < jsonStr.Length; i++)
            {
                char c = jsonStr[i];

                if (c == '[')
                {
                    isValue = true;
                }
                else if (c == ']')
                {
                    isValue = false;
                    weatherCodePairs.Add(key, value.Split(','));
                    key = string.Empty;
                    value = string.Empty ;
                }

                else if (isValue == false && c == '"')
                {
                    isKey = !isKey;
                }

                else if (isKey == true)
                {
                    key += c;
                }
                else if (isValue == true)
                {
                    value += c;
                }
            }
            return weatherCodePairs;
        }
    }
}
