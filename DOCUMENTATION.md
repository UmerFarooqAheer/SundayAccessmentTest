The purpose of this document is to describe the challenges and a brief explanation about the issue and how it got resolved. Following headings are the challenges with explanation enclosed.

**# Critical Issues:**

* **# Git Repository:**
=> Challenge:  There are issues with the git repository as numerous irrelevant files are included in pushes.

=> Solution: A lot of files which shouldn't necessariliy be the part of unity project and should be excluded were not being excluded from the project and they were committed already. Adding the .gitignore file eclosing the extensions of all unwanted file types not only on root level but also if they exist in deep folder hierarchy resolved the problem.


* **# CODE RELATED IMPROVEMENTS(Performance Issues & * Frame Rate Dependency)**
=> Challenge(s): 
1. Despite the game having minimal objects and scripts, performance issues persist on mobile devices.
2. Controls behave inconsistently depending on the frames per second (FPS) the game is running at.

=> # **Solution:** Some bad practices were being followed in a few scripts which added spike in the profiler indicating huge script/code cost. Removing those bad practices and replacing with good ones resolved the problem. Following is detailed explanation.

-> GameObject.Find("PlayerBall").
Finding GameObject from the hierarchy must be avoided because its a costly call, specially when there are alot of gamobjects in the scene.So, approach should be to either Serialize Field Or make sure that getting the reference to any script or gameobject is not happening over and over again in methods like update or loops.
-> .GetComponent<Rigidbody>()
This one is very similar to the last problem, even adding cost of Getting component from gameobject as well.
GameObject.Find("PlayerBall").GetComponent<Rigidbody>() in the update method is a HUGE cost because it runs on every frame and go thorugh all gameobjects in the hierarchy to first find the gameobject and then the component attached on it.
-> ballRigidbody.AddTorque((Vector3.forward * diff.x + Vector3.right * -diff.y) * torqueAmount, ForceMode.VelocityChange); in Update method.
Update method is supposed to have code which should be executed everyframe(like getting input etc), physics related stuff should not be placed inside update method. It should be executed in the FixedUpdate method so that the performance should be uniform and experience should be smoother.
-> Logic inside the update method is improved now since it needs to be optimized.
-> Removed the magic values and push the code which needed to be used across the project into GameManager which is accessible from any where in the project. This ended up giving us freedom to scale and maintain the game.


* # **MyEventSystem Class:** "MyEventSystem class is unable to find GameAnalytics"
=> Challenge(s): GameAnalytics is required to have it's own assmebly

=> # **Solution:**

Bonus Issues: GameAnalytics required to have their own Assembly definition, not only on the root level but also in the Editor folder becuase otherwise the build would fail.So, creating the required assembly definition files and passing them around in the required way resolved the issue.

* # **Level Management:** 
Challenge: Adding and managing new levels within the project is challenging.
Solution: 
-> Removed the magic values and push the code which needed to be used across the project into GameManager which is accessible from any where in the project. This ended up giving us freedom to scale and maintain the game.
-> Introduced scriptable objects in the project which come with the beauty of indepences and modularity.
-> Since the levels are pretty small and can have a prefab for each level. I used approach to use prefabs instead of using levels, which will eventually help reduce the size of the project as well.

* # **Firebase Analytics Integration:** 
Challenge: Firebase Analytics integration is missing. I need to send the same events (start, fail, and finish) tracked by Game Analytics to Firebase too.

**# Solution**: Looked into documentation of firebase and searched the relevant .unitypackage we require for Firebase Analytics. Importing the package and sending the event gave wanted results.
