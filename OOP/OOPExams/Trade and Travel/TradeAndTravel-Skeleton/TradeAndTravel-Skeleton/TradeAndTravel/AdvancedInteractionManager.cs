using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class AdvancedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                default:
                    break;
            }
            return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "forest":
                    location = new Forest(locationName);
                    break;
                case "mine":
                    location = new Mine(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }

            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(actor, commandWords[2]);
                    break;
                case "craft":
                    HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;
                default: 
                    break;
            }
            base.HandlePersonCommand(commandWords, actor);
        }

        private void HandleCraftInteraction(Person actor, string itemTypeAsString, string newItemName)
        {
            var actorInventory = actor.ListInventory();
            Item itemToAdd = null;
            var listOfNeededItems = null;

            switch (itemTypeAsString)
            {
                case "weapon" :
                    if (actorInventory.Any(x => x.ItemType == ItemType.Wood) && actorInventory.Any(x => x.ItemType == ItemType.Iron))
                    {
                        itemToAdd = new Weapon(newItemName);
                    }
                    break;
                case "armor" :
                    if (actorInventory.Any(x => x.ItemType == ItemType.Iron))
                    {
                        itemToAdd = new Armor(newItemName);
                    }
                    break;
                default:
                    break;
            }

            if (itemToAdd != null)
            {
                this.AddToPerson(actor, itemToAdd);
            }
        }

        private void HandleGatherInteraction(Person actor, string newItemName)
        {
            var gatherLocation = actor.Location as IGatheringLocation;
            if (gatherLocation == null)
            {
                return;
            }

            if (actor.ListInventory().Any(x => x.ItemType == gatherLocation.RequiredItem))
            {
                var itemReward = gatherLocation.ProduceItem(newItemName);
                this.AddToPerson(actor, itemReward);
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant" :
                    person = new Merchant(personNameString, personLocation);
                    break;
                default: return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
            return person;
        }
    }
}
