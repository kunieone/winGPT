using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Spectre.Console;

public enum BotType { Auto, Paragraph, Email, Blog, Ideas, Outline, QA };
public enum Tone { Friendly, Professional, Polite };
public enum BotLength { Auto, Short, Medium, Long };
public class WinGPT
{

    string chatHistory = "";
    private string secretKey = "key";
    private string url = "https://api.openai.com/v1/chat/completions";
    public void AddMsg(string message)
    {
        chatHistory += "User:" + message + "\n";
    }
    public void AddGPTReply(string message)
    {
        chatHistory += "You:" + message + "\n";
    }
    public WinGPT(BotType bt, Tone tn, BotLength bl)
    {
        this.chatHistory = WinGPT.transformPreConversation(BotType.Auto, Tone.Friendly, BotLength.Auto);
    }
    public async Task<string> Ask()
    {
        // 在这里完成实际的请求处理逻辑
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.secretKey}");
        var requestJson = JsonConvert.SerializeObject(new
        {
            messages = this.chatHistory,
            model = "gpt-3.5-turbo",
            max_tokens = 300,
        });


        var requestContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");
        var httpResponseMessage = await httpClient.PostAsync(this.url, requestContent);
        var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeAnonymousType(jsonString, new
        {
            choices = new[] { new { message = new { role = string.Empty, content = string.Empty } } },
            error = new { message = string.Empty }
        });


        // Check for errors
        if (!string.IsNullOrEmpty(responseObject?.error?.message))
        {
            return responseObject?.error?.message!;
        }
        else
        {
            var messageReply = responseObject?.choices[0].message.content;
            AddGPTReply(messageReply!);
            return messageReply!;
        }

    }

    public void Clear()
    {
        chatHistory = "";
    }

    public string GetChatHistory()
    {
        return chatHistory;
    }



    public static string transformPreConversation(BotType bt, Tone tone, BotLength length)
    {
        string tmp = "prompt: 你现在是";
        switch (bt)
        {
            case BotType.Auto:
                tmp += "一个综合的，";
                break;
            case BotType.Paragraph:
                tmp += "用于返回正式文章的，";
                break;
            case BotType.Email:
                tmp += "用于帮助创作电子邮件的";
                break;
            case BotType.QA:
                tmp += "问答模式下的";
                break;
            case BotType.Blog:
                tmp += "用于辅助创建博客文章的";
                break;
            case BotType.Ideas:
                tmp += "用于提供创新性想法的";
                break;
            case BotType.Outline:
                tmp += "用于概括文章内容大纲的";
                break;
            default:
                break;
        }
        tmp += "AI助理,请使用";

        switch (tone)
        {
            case Tone.Friendly:
                tmp += "友好的";
                break;
            case Tone.Professional:
                tmp += "专业的";
                break;
            case Tone.Polite:
                tmp += "礼貌的";
                break;
            default:
                break;
        }
        tmp += "语气提供服务。";

        switch (length)
        {
            case BotLength.Short:
                tmp += "在这个模式下，请你简短地回答问题。";
                break;
            case BotLength.Medium:
                tmp += "在这个模式下，请你提供一些详细的信息以回答问题。";
                break;
            case BotLength.Long:
                tmp += "在这个模式下，请你提供非常详细的信息以回答问题。";
                break;
            default:
                break;
        }

        return tmp;
    }


}


