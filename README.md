## Paige

A desktop mood tracker built with WPF and C#

This branch (which is `main` as of writing this) is the functional skeleton. It has all the core features work, but the UI is intentionally basic. It has no custom styling.

### What it does
- Allows a user to log their day in one of two ways:
  1. Quick entry: rate how their day was, and optionally add a short note and photo.
  2. Full entry: same first steps as quick entry, but there are other menus that ask about specifics, like what the user ate that day, what hobbies they partook in, etc. It also asks for the photo at the end.
- A user can view past entries in a calendar-like view. Once they select a day, it shows all details of that entry, including the photo and the specifics (if applicable).
- Optionally, users can wrote journals entries for each day. They can also view that day's journal entry through the mood calendar.

### Tech Stack
- WPF (.NET)
- C#
- MVVM architecture
- JSON file storage

### Branches
| Branch | Description |
|---|---|
| `main` | Functional skeleton (plain WPF controls) |
| `ui-polish` | Redesigned UI built on top of the same backend |

### Future Plans
1. Implement a polished UI that looks nice on ui-polish branch, move plain program to new `legacy` branch, make ui-polish branch into main :steamhappy:
2. After the UI is done, learn SQL, migrate the data from the JSON layer to an SQL layer.
3. After SQL layer is done, make it cloud based, so that users can login and access their data across devices.
4. Once the cloud-based version is complete, work on adding a "daily question" tab, where each day a pre-set question will be asked. The user can answer said question, and view past answers on the mood calendar.
5. This one is a very heavy MAYBE. Work on migrating the codebase to .NET MAUI, so that the app can be operated and viewed on mobile devices. This would take a REALLY long time, and a LOT of refactoring. So, it's definitely not a set-in-stone plan, its mostly just gonna be done if I have the drive to make this and have no other ideas for other projects.
