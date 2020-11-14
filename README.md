# NPCBuilder
 An NPC Building solution for Unity3D. Allows you to create NPC models by combining body parts in different variations together.

Based upon https://github.com/masterprompt/ModelStitching

# Installation
Download the .unitypackage file from the Releases tab and Import it into Unity

# Usage
Since the original usage of this tool was to put *clothing* on a model, your NPC avatar needs a base model for the other pieces to be stiched onto. This can be a generic body that they all share, or even an invisible piece if you want to build a full model.

## Model Assembly
In order to utilize this tool, you'll need to prepare your body part models in a specific way:
* Each "body part" must be a separate object within your 3D modeling program
* All the parts must be rigged to the same skeleton
* Models *can* share a material, but do not have to
* Model should be a \*.fbx file with skeleton data included

## Creating NPC Body Parts
A full NPC is comprised of any number of body parts you want. The way this tool is setup is for low-poly models so it uses 5 parts:
* Head
* Body
* Right Arm
* Left Arm
* Legs

You'll need to create the data for each individual piece you want to be usable by the Builder. This can be done by opening your project window and right clicking,  Create > NPC Builder > NPC Body Part

## Creating an NPC Template
In order for the builder to create your NPC, it needs a template telling it which parts to use.
* Create an NPC Template by opening your project window and right clicking, Create > NPC Builder > NPC Template
* In the Template File, select the number of body parts to use (5 for standard models) and drag in the associated body part.

Your NPC Template can now be used by the NPC Builder component.

## Using the NPCBuilder Component
* Attach this component to your NPC GameObject containing the logic for controlling how the NPC moves etc.
* Drag in your NPC Data file and the Base model into their respective property fields

## Using the NPC Generator
If you wish to create a large number of NPCs with variations of models for the different body parts, you can use the included NPC Generator Window to do that
* At the top Menu, select NPC Builder > NPC Generator
* Select the number of NPCs you wish to Generate
* Select the number of body part variations to use for each different body part
* Select the body part variations you wish to us
* Hit "Generate"

Your Generated NPCs can be found in Assets/NPCBuilder/Data/
