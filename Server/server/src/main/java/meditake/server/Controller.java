package meditake.server;

import java.io.IOException;

import org.json.simple.parser.ParseException;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import meditake.server.chatGPT.ChatGPT;

@RestController
public class Controller {
	@GetMapping("/test")
	public String test() throws IOException, ParseException{
		ChatGPT chatGPT = new ChatGPT();
		return chatGPT.generateText("hi", 1.0f, 1000);
	}
}
