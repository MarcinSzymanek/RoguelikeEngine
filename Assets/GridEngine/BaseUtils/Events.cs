using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


namespace GridEngine{
	namespace Events{
		// EventPublisher stores events

		public class EventPublisher{
			Dictionary<string, EventObject> eventList = new Dictionary<string, EventObject>();
			Dictionary<string, List<subscriber>> subscriberList = new Dictionary<string, List<subscriber>>();
			
			ObjectIDGenerator idGen = new ObjectIDGenerator();
			
			static int subCount = 0;
			
			struct subscriber{
				public subscriber(EventObject.eventHandler h_, long id_){handler = h_; id = id_;}
				public EventObject.eventHandler handler;
				public long id;
			};
			
			public bool addEvent(string name){
				if(!checkEventExists(name)){
					EventObject newEvent = new EventObject(name);
					eventList.Add(name, newEvent);
					subscriberList.Add(name, new List<subscriber>());
					Debug.Log("Event added to the publisher");
					return true;
				}
				Debug.Log("Event already in the list!");
				return false;
			}
			
			public bool checkEventExists(string name){
				return eventList.ContainsKey(name);
			}
			
			// Iterate through a subscriberList to check if the id matches
			public bool checkSubscibed(string name, long id){
				foreach(subscriber sub in subscriberList[name]){
					if(sub.id == id){
						return true;
					}
				}
				return false;
			}
			
			public int findSubscriber(string name, long id){
				foreach(subscriber sub in subscriberList[name]){
					if(sub.id == id){
						return subscriberList[name].IndexOf(sub);
					}
				}
				return -1;
			}
			
			public bool raiseEvent(string name){
				if(checkEventExists(name)){
					if(eventList[name].checkNotEmpty()){
						// Debug.Log("Event " + name + " raised!");
						eventList[name].onEvent();
						return true;
					}
					Debug.Log("Event list empty!");
				}
				Debug.Log("Could not raise event " + name);
				return false;
			}
			
			
			public void subscribeTo(string name, Object obj, System.Action handler){
				// Check if the event is in the event list
				// If so, check if the object has already subscribed
				if(checkEventExists(name)){
					bool neverProcessed;
					long ID = idGen.GetId(obj, out neverProcessed);
					Debug.Log("Object ID = " + ID);
					Debug.Log("Object already ID'd = " + neverProcessed);
					if(!neverProcessed){
						// Check if the object has already subscribed, if so cancel
						if(checkSubscibed(name, ID)){
							Debug.Log("Object already subscribed, cancelling");
							return;
						}
					}
					
					// Create a new subscriber object, add to subscriberList
					EventObject.eventHandler newSub = new EventObject.eventHandler(handler);
					eventList[name].eventPublisher += newSub;
					subCount++;
					subscriber sub = new subscriber(newSub, ID);
					subscriberList[name].Add(sub);
					Debug.Log("Succesfully added subscriber");				
				}
				return;
			}
			
			public bool unsubscribe(string name, Object obj){
				bool subscribed;
				long ID = idGen.GetId(obj, out subscribed);
				int index = findSubscriber(name, ID);
				if(index > -1){
					eventList[name].eventPublisher -= subscriberList[name][index].handler;
					subscriberList[name].RemoveAt(index);
					Debug.Log("Succesfully unsubscribed");
					return true;
				}
				return false;
			}
		}
		
		
		public class EventObject{
			public EventObject(string name){eventName = name;}
			public string eventName;
			public delegate void eventHandler();
			public event eventHandler eventPublisher;
			
			public void onEvent(){
				eventPublisher?.DynamicInvoke();
			}
			
			public bool checkNotEmpty(){
				if(eventPublisher != null){
					return true;
				}
				return false;
			}
		}
	}	
}

