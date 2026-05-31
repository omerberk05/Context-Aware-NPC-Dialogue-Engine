# Context-Aware and Memory-Driven NPC Dialogue Engine

## Project Description

This project presents a Context-Aware and Memory-Driven NPC Dialogue Engine developed in Unity. The system enables NPCs to remember previous player interactions and generate different dialogue outcomes based on the player's past decisions.

The architecture combines a dialogue management system, contextual memory storage, a scoring mechanism, and a Finite State Machine (FSM) to provide continuous and adaptive NPC interactions.

## Features

- FSM-based dialogue management
- Contextual memory system
- Memory event tracking
- Score-based relationship evaluation
- Continuous multi-stage dialogue flow
- Dynamic dialogue outcomes based on previous interactions
- Modular architecture for future expansion

## Project Structure

### DialogueManager
Controls dialogue flow, dialogue stages, and user interaction.

### DialogueData
Stores dialogue texts, player choices, responses, memory events, and score values.

### NPCMemory
Stores memory events and maintains the relationship score.

### MemoryEvent
Represents a contextual memory entry including Event Name, Impact Value, Dialogue Stage, and Timestamp.

### NPCFSM
Determines NPC states according to accumulated score values.

States:
- Friendly
- Neutral
- Suspicious

### NPCInteraction
Handles player-NPC interaction detection.

### PlayerMovement
Controls player movement within the scene.

## Controls

- E : Start Conversation
- G : Previous Choice
- H : Next Choice
- F : Confirm Choice

## Dialogue Flow

Interaction 1:
- Player chooses to help or refuse the NPC.

Interaction 2:
- NPC remembers the previous decision.
- New dialogue options are presented.

Interaction 3:
- The NPC evaluates the entire interaction history.
- Final dialogue is determined through FSM state transitions.

## FSM Logic

Friendly:
- Score >= 6

Neutral:
- Score >= 0 and Score < 6

Suspicious:
- Score < 0

## Development Environment

- Unity 6
- C#
- TextMeshPro

## Running the Project

1. Open the project using Unity Hub.
2. Open the MainScene scene.
3. Press Play.
4. Approach the NPC and press E to start interaction.
