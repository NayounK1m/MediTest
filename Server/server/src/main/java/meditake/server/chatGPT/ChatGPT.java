package meditake.server.chatGPT;

import java.io.FileReader;
import java.io.IOException;
import java.io.Reader;
import java.util.HashMap;
import java.util.Map;

import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.client.RestTemplate;

public class ChatGPT {
	private static String key;
	private static final String ENDPOINT = "https://api.openai.com/v1/completions";

	public ChatGPT() throws IOException, ParseException {
		JSONParser parser = new JSONParser();

		Reader reader = new FileReader("C:\\chatGPT.json");
		JSONObject jsonObject = (JSONObject)parser.parse(reader);
 		key = (String) jsonObject.get("key");
	}

	public String generateText(String prompt, float temperature, int maxTokens) {
		HttpHeaders headers = new HttpHeaders();
		headers.setContentType(MediaType.APPLICATION_JSON);
		headers.set("Authorization", "Bearer " + key);

		Map<String, Object> requestBody = new HashMap<>();
		requestBody.put("model","text-davinci-003");
		requestBody.put("prompt", prompt);
		requestBody.put("temperature", temperature);
		requestBody.put("max_tokens", maxTokens);

		HttpEntity<Map<String, Object>> requestEntity = new HttpEntity<>(requestBody, headers);

		RestTemplate restTemplate = new RestTemplate();
		ResponseEntity<Map> response = restTemplate.postForEntity(ENDPOINT, requestEntity, Map.class);
		return response.toString();
	}
	public static String getKey() {
		return "key: "+ ChatGPT.key;
	}
}
