# cátte — Selection Helper

Unity Editor package to make selecting certain objects easier and less tedious.

## Features

- **Quick Selection Tools**: Select immediate children, filter by type, select by type in children/parents
- **Save/Load Selection**: Save and restore object selections
- **Scene Object Selector**: Visual scene view tool for selecting transforms with customizable handles
- **Type-Based Selection**: Choose a component type and filter selections based on it
- **Flexible Context Menus**: Right-click components to choose selection type

## Installation

Install via VRChat Creator Companion (VCC) or add to your Unity project's Packages folder.

## Usage

### Basic Selection Tools
Access via `Tools > ⚙️🎨 kittyn.cat 🐟 > Selection Helper`:
- **Select Immediate Children**: Select all direct children of selected objects
- **By Type > Filter**: Filter current selection to only objects with the chosen component type
- **By Type > Children**: Select all children with the chosen component type
- **By Type > Parents**: Select all parents with the chosen component type

### Choosing Component Type
Right-click any component in the Inspector and select `[SH] Choose Type` to set the active component type for filtering.

### Save/Load Selection
- **Save Selection**: Save current selection for later use
- **Load Selection**: Restore previously saved selection

### Scene Object Selector
Access settings via the menu. Use the scene view button to toggle visual bone/transform selection mode with customizable handle sizes and colors.

## Requirements

- Unity 2019.4 or later

## License

MIT License - see LICENSE.md file for details
