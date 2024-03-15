# Jixi Unity Demo

Jixi is an all-in-one AI development platform. This demo takes Unity's adventure sample and adds AI NPC interaction built on Jixi.

Original game: https://assetstore.unity.com/packages/templates/tutorials/adventure-sample-game-76216

Jixi SDK: https://github.com/jixi-ai/jixi-unity-sdk

<img width="954" alt="Screenshot 2024-03-15 at 10 45 50 AM" src="https://github.com/jixi-ai/jixi-unity-demo/assets/2688048/60374934-3a08-435e-8974-017e8f958015">

# Jixi Setup

### Create an Account

1. Navigate to https://app.jixi.ai/
2. Create an account, verify your email, and log in

### Create an Action for your NPC

1. Go to `Actions` and click `New Action`. Give it a name and description, and then click `Create`

<img width="1706" alt="Screenshot 2024-03-15 at 3 33 05 PM" src="https://github.com/jixi-ai/jixi-unity-demo/assets/2688048/75726279-4680-47f9-953d-918aa2f178cc">

1. Click on the new action
2. Replace the code with:

```jsx
// Click 'Run' to execute
async function execute(userInput) {

  const config = {
    role: "You are an NPC character for my game. Your name is Mr Fishman. You sell fish. You're having a conversation with the player. You're friendly, helpful, but also a bit vauge when helping the player",

    prompt: `Respond to '${userInput.playerInput}'`,

    response: {
      dialogue: "string",
    },
  }

  // Generate with AI
  return await jixi.askAI(config);
}

```

1. Try testing your new AI action! Click on `Test` and navigate to `Input`. Replace the JSON with:

```json
{
  "playerInput": "Hello!"
}

```

<img width="1716" alt="Screenshot 2024-03-15 at 3 39 41 PM" src="https://github.com/jixi-ai/jixi-unity-demo/assets/2688048/9f80de15-9c24-4c6f-87ea-461268cc5a47">


1. Click `Run` and navigate to `Result` to see the AI response
2. Copy the Action's URL. We'll be adding it to our Unity game

### Add Files

Right now we're able to have a conversation with our AI NPC, but our character does not have much information about the world. Let's fix that by adding some files to the `Files` section

1. Navigate to `Files`
2. Download [game-rules.txt](https://github.com/jixi-ai/jixi-unity-demo/blob/main/Jixi%20AI/game-rules.txt) and [character-info.txt](https://github.com/jixi-ai/jixi-unity-demo/blob/main/Jixi%20AI/character-info.txt) and drag them into `Files` to upload them. You can also use your own files, Jixi can process `txt` `pdf` `doc` `ppt` `rtf` `html` files and more
3. Try testing your NPC action again and notice the character has knowledge of our game rules and a backstory


<img width="1717" alt="Screenshot 2024-03-15 at 3 50 50 PM" src="https://github.com/jixi-ai/jixi-unity-demo/assets/2688048/c2796ab7-18ec-4f1c-b634-5f1aa761349c">


### Create an API Key
1. Navigate to `API Keys` and click `New API Key`
2. Give it a name (ex `My Unity API Key`
3. Click `Create` and copy the API key. ** This Key isn't shown again so make sure to copy it **

<img width="1720" alt="Screenshot 2024-03-15 at 4 02 43 PM" src="https://github.com/jixi-ai/jixi-unity-demo/assets/2688048/d2aaeedd-a97b-4a4d-aaa5-cefd1b77244f">

# Unity Setup

Now that our AI is setup, let's add it to our Unity game

1. Open the Unity project. The project is running on Unity LTS 2021
2. Open `Assets -> Demo Game -> Scenes -> Persistent.unity`
3. Find the `Jixi AI` prefab. It should exist in the scene already
4. Fill out the inspector with your own values - the API key you created, and the action's URL. The action name does not need to match, although it's good practice
   
<img width="354" alt="Screenshot 2024-03-15 at 4 08 49 PM" src="https://github.com/jixi-ai/jixi-unity-demo/assets/2688048/b14ba9cc-a36d-411f-a537-2dd25dac4d0a">

5. The project is setup to use the name `Fishman` as shown in the picture. To use something else, open `TextConversationReaction.cs` found at `Assets/Demo Game/Scripts/ScriptableObjects/Interaction/Reactions/DelayedReactions/TextConversationReaction.cs` and update the `Jixi.Call` method

```csharp
// Change 'Fishman' to whatever your action name is on the Jixi AI prefab
Jixi.Instance.Call(jixiAIConfig.GetActionUrl("Fishman"), playerInputJson, (DialogueResponse response) =>
{
    textManager.DisplayMessage(response.dialogue, textColor, delay);
});    
```

6. Hit 'Play' and go talk to the fish seller!

# More Resources

For more information on adding Jixi to Unity games, see the SDK here: https://github.com/jixi-ai/jixi-unity-sdk
