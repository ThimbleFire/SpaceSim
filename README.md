# SpaceSim

![image](https://github.com/ThimbleFire/SpaceSim/assets/14812476/5d4e8c44-1746-4a81-b76a-d7b391440576)

To do:
* Prototype the Star Map
* Planet-side design
* Dialog
* Changing from 2D to 3D
    * Model NPCs
    * Model ships

Currently making a state machine from Unity Graphs to make the AI better.

This will include nodes like
* Exposed properties (behaviours, jobs, impulses)
* Facility filters (isOperational, isInOperation)
* Exposed Property boolean operations (greaterThan, greaterThanEqualTo, equalTo, lessThanEqualTo, lessThan)
* Pathfinding
* Math operations (shortestDistance)
* Facility interact (maybe)
* Invoke action (maybe)
* Log (print)
* End Node
* Switch Statements
Can we design nodes around specific exposed properties?

Make Nodes (like InstructionNode) inherit from BaseNode. BaseNode includes its name, GUID, and a method that serves its purpose and calls its appropriate option. If this is even possible.

ships can only connect facilities with compatible sizes.

Shuttle - very small (12x7x1)
Frigate - medium (8x14x1)
Galleon - large (15x10x2)
Battleship - very large (10x20x3)
Goliath - giant (15x25x5)

facilities need calibrating by the engineer after being installed and before they can be used.


Space is big. There's a 4x4x4 grid of universes with the following names:

1. Leon
2. Sarcoph
3. Kalvashi
4. Numaki
5. Rosswell
6. Terilla
7. Moriarty
8. Atomos
9. Cerno
10. Cardo
11. Phalix
12. Janua
13. Old Bailey
14. XN-IX
15. XN-XIV
16. Muertuun
17. Nostralis
18. O'aki
19. Eclipse
20. Ruinova
21. Ormus
22. Malace
23. Ral
24. Dominion
25. Neuton
26. Suen
27. Gigalad
28. Stratos
29. XN-III
30. New Haven
31. Forbiddena
32. Sanctuary
33. Calimax
34. San Cosina
35. Rezifarg
36. Calipso
37. Intuerno
38. Damoros
39. Barados
40. Coloss
41. Temporus
42. Britannica
43. Leviathan
44. Sol
45. Peridot
46. Satalite
47. XN-VII
48. Scarbell
49. Quiloyd
50. Zenema
51. Xandi
52. I'Anna
53. Gorgashu
54. Meekantac
55. Austriallah
56. Boreallah
57. Morbolm
58. Tsunet
59. Inevi
60. Llano
61. Drunvalo
62. Borbash
63. Arryatlee
64. Reldawin

Later...

* [ ] NPCs currently subscribe to job facilities while perfoming jobs.
      While perfoming jobs there's a <rank>/256 chance they'll aquire knowledge.
      The knowledge that facilities offers change according to event circumstance.
* [ ] Add List<Knowledge> to Entities, where Knowledge is type enum { Destination, DamagedFacility, GunneryTarget, Sickness 
