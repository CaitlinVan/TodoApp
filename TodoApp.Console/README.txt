This project utilizes: 
- C# 
- PostgreSQL (using Docker) 
- Avalonia 

For this app, I've used MVVM to practice and become more familiar with different software architecture types. 
Since it will be the first time, i will be using this type of structure (MVVM) instead of three-layered (See other projects in GitHub and GitLab). 
The reason why I've chosen MVVM is due to its heavy reliance on UI and its fit with Avalonia. 

Thoughts and design: 
- During the initial stages, I brainstormed functional and non-functional requirements for the app. I sorted the requirements into MoSCoW (see attached document).
- After establishing the first draft of requirements, I generated an ER-diagram based on selected entities and their relationships. (See attached image) 
 
- The "V2"/ version 2 branch were created after all "V1"/Version 1 functionalities were implemented (All "Musts" from MoSCoW requirements). 
"V2" includes the "Should have" and "Could have" functionalities. 

- F.11 Rename - Behavior (changing datatemplate's textblock to textbox): 
since TextBox.Text="{Binding Name}" is two-way by default, the moment the user types anything, list.Name changes in memory immediately — even before they click Save. 
This means if they type a new name and then click Delete instead of Save, the rename never got persisted (fine, no bug), 
but if they type a name and navigate away without clicking Save, 
the in-memory object has the new name but the database still has the old one — until the next LoadListsAsync() call,
which would silently overwrite their unsaved edit back to whatever's in the database. 
Not a blocking issue for v1, just worth knowing the behavior.

- Changes in MainWindow.axaml: 
  - line 72 (Add "TargetNullValue= Unsorted" so when selecting a list, it shows unsorted and not blank) 
  - Change in line 69 ([IsVisible="{Binding !IsBoardView}"] needs to be changed because the code doesn't allow "toggle" function to work. It is apparently due to Avalonia, it doesn't support complied "!") 

- MVVM
  - Uses "RelayCommand" so user interface controls (like buttons) can trigger actions in ViewModels without using code behind (Practicing MVVM).
 
 
  
  



