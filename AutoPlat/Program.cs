// See https://aka.ms/new-console-template for more information
using AutoPlat.Models;
using AutoPlat.Models.BaseModels;

TriggerChest chest  = new TriggerChest();

Trigger triggerMessage = new Trigger(chest);



triggerMessage.SetConditions([new KeyPressedCond(ConsoleKey.M)]);



triggerMessage.SetActions([new PrintMessageAction("New message recived!")]);


chest.StartUpdate(17);
