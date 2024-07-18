//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_VartraAbyss/Input/VampireGame.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @VampireGame: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @VampireGame()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""VampireGame"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ddae2226-6a48-4033-b4d9-690243213c72"",
            ""actions"": [
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""6276dda3-f691-4ef0-8e27-0a1339545de5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""7f77f20c-a431-4b51-aac3-fc8d1087bcec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HealthPotion"",
                    ""type"": ""Button"",
                    ""id"": ""b320da31-6e49-45b5-8116-6473f341df04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ManaPotion"",
                    ""type"": ""Button"",
                    ""id"": ""762ea1c1-aabd-43c4-8fd0-71f75156e063"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability1"",
                    ""type"": ""Button"",
                    ""id"": ""0bb03b55-c52f-41c9-bed3-5391c4ddfb15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability2"",
                    ""type"": ""Button"",
                    ""id"": ""70d10c97-8e1d-4a73-aea9-6f45ac062e42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability3"",
                    ""type"": ""Button"",
                    ""id"": ""fd11a80e-7f82-4256-b940-cb9dac9e990c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability4"",
                    ""type"": ""Button"",
                    ""id"": ""10696725-d86f-4ec1-ba84-a91db798ae2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability5"",
                    ""type"": ""Button"",
                    ""id"": ""c62b2841-7fae-438b-89b7-613e9d5597aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Potion"",
                    ""type"": ""Button"",
                    ""id"": ""98a2c977-0217-4be5-8346-469ec5dfc1e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Force Move"",
                    ""type"": ""Button"",
                    ""id"": ""ba5cc00f-7d77-4c46-9cf3-61509328384c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Force Still"",
                    ""type"": ""Button"",
                    ""id"": ""001cf8e9-1993-4fad-b735-348488b71fb9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""90d4c0f6-7dc3-41af-a3be-c034ddb1fbd5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""6eec006b-f3b4-4702-86c5-cbc73eeeb7ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skills"",
                    ""type"": ""Button"",
                    ""id"": ""9d463777-fff6-4914-8abe-16b47c335b71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Expand Map"",
                    ""type"": ""Button"",
                    ""id"": ""cab346c9-0074-47b1-9493-8b2acb3fd481"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AbsorbAbility"",
                    ""type"": ""Button"",
                    ""id"": ""1bcac1f8-35ab-46f5-93c8-1644a2d6b82d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""7c8f33b2-83ed-40a4-92b6-ea37698c284c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dad84e79-6e50-4ae7-95e1-d0fbac431b37"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b7c0e73-ae11-4e1d-b6bc-47d38d76ee76"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c44ce0b6-ba33-4e05-8065-7fdd0e5b2065"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HealthPotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5e3f195-101f-4540-a5db-614aa43e8807"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ManaPotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63ad95cf-68b7-4869-8b25-bb3fe0736d8f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdd8c078-f84d-458a-a670-4ed9f95ac1e9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c210bb60-7e4c-46a0-8cdf-b41bc910edca"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Potion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6600c396-df5d-4ed6-aaac-65cb0f405c65"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Force Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ab0c249-c43c-4ce2-8f40-96d207c00b63"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Force Still"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6456b7a8-1917-49ad-b1c8-1a8042e55098"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdaa9192-1ae2-437d-9132-d934a12329b2"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9f8d5dc-b40c-4eef-9939-abb86e379353"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skills"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""141f5fdf-2c64-4334-8bdc-99139f0e3a10"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Expand Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a185c60-1da6-4ea9-b2fa-8779524c1508"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbsorbAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b037637-21a5-4375-86e8-34cc7737d9a8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e3750a7-03c4-4111-a946-444e9bb787bf"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38b289fc-d37d-43e3-b53f-f2471f09e6e1"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""753c6caf-e90e-4425-8918-1e196a575888"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialogue"",
            ""id"": ""3c99d032-d988-466f-8bca-deea3cac7567"",
            ""actions"": [
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""48769ed5-498d-449b-9437-c63cf4ce5984"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""46ad8c11-fe08-4175-aa7c-ff5a85d8cdbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""a1495002-900b-4881-a119-165ccaae707c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4d866982-9fd8-4c3e-83eb-c8751374904c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b5330c1-c7d1-4bd3-872e-f62cc3a4e744"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fdc49543-5068-4b94-b3c0-5a4ac08ab2c2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Primary = m_Player.FindAction("Primary", throwIfNotFound: true);
        m_Player_Secondary = m_Player.FindAction("Secondary", throwIfNotFound: true);
        m_Player_HealthPotion = m_Player.FindAction("HealthPotion", throwIfNotFound: true);
        m_Player_ManaPotion = m_Player.FindAction("ManaPotion", throwIfNotFound: true);
        m_Player_Ability1 = m_Player.FindAction("Ability1", throwIfNotFound: true);
        m_Player_Ability2 = m_Player.FindAction("Ability2", throwIfNotFound: true);
        m_Player_Ability3 = m_Player.FindAction("Ability3", throwIfNotFound: true);
        m_Player_Ability4 = m_Player.FindAction("Ability4", throwIfNotFound: true);
        m_Player_Ability5 = m_Player.FindAction("Ability5", throwIfNotFound: true);
        m_Player_Potion = m_Player.FindAction("Potion", throwIfNotFound: true);
        m_Player_ForceMove = m_Player.FindAction("Force Move", throwIfNotFound: true);
        m_Player_ForceStill = m_Player.FindAction("Force Still", throwIfNotFound: true);
        m_Player_Menu = m_Player.FindAction("Menu", throwIfNotFound: true);
        m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
        m_Player_Skills = m_Player.FindAction("Skills", throwIfNotFound: true);
        m_Player_ExpandMap = m_Player.FindAction("Expand Map", throwIfNotFound: true);
        m_Player_AbsorbAbility = m_Player.FindAction("AbsorbAbility", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        // Dialogue
        m_Dialogue = asset.FindActionMap("Dialogue", throwIfNotFound: true);
        m_Dialogue_Primary = m_Dialogue.FindAction("Primary", throwIfNotFound: true);
        m_Dialogue_Secondary = m_Dialogue.FindAction("Secondary", throwIfNotFound: true);
        m_Dialogue_Menu = m_Dialogue.FindAction("Menu", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Primary;
    private readonly InputAction m_Player_Secondary;
    private readonly InputAction m_Player_HealthPotion;
    private readonly InputAction m_Player_ManaPotion;
    private readonly InputAction m_Player_Ability1;
    private readonly InputAction m_Player_Ability2;
    private readonly InputAction m_Player_Ability3;
    private readonly InputAction m_Player_Ability4;
    private readonly InputAction m_Player_Ability5;
    private readonly InputAction m_Player_Potion;
    private readonly InputAction m_Player_ForceMove;
    private readonly InputAction m_Player_ForceStill;
    private readonly InputAction m_Player_Menu;
    private readonly InputAction m_Player_Inventory;
    private readonly InputAction m_Player_Skills;
    private readonly InputAction m_Player_ExpandMap;
    private readonly InputAction m_Player_AbsorbAbility;
    private readonly InputAction m_Player_Pause;
    public struct PlayerActions
    {
        private @VampireGame m_Wrapper;
        public PlayerActions(@VampireGame wrapper) { m_Wrapper = wrapper; }
        public InputAction @Primary => m_Wrapper.m_Player_Primary;
        public InputAction @Secondary => m_Wrapper.m_Player_Secondary;
        public InputAction @HealthPotion => m_Wrapper.m_Player_HealthPotion;
        public InputAction @ManaPotion => m_Wrapper.m_Player_ManaPotion;
        public InputAction @Ability1 => m_Wrapper.m_Player_Ability1;
        public InputAction @Ability2 => m_Wrapper.m_Player_Ability2;
        public InputAction @Ability3 => m_Wrapper.m_Player_Ability3;
        public InputAction @Ability4 => m_Wrapper.m_Player_Ability4;
        public InputAction @Ability5 => m_Wrapper.m_Player_Ability5;
        public InputAction @Potion => m_Wrapper.m_Player_Potion;
        public InputAction @ForceMove => m_Wrapper.m_Player_ForceMove;
        public InputAction @ForceStill => m_Wrapper.m_Player_ForceStill;
        public InputAction @Menu => m_Wrapper.m_Player_Menu;
        public InputAction @Inventory => m_Wrapper.m_Player_Inventory;
        public InputAction @Skills => m_Wrapper.m_Player_Skills;
        public InputAction @ExpandMap => m_Wrapper.m_Player_ExpandMap;
        public InputAction @AbsorbAbility => m_Wrapper.m_Player_AbsorbAbility;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Primary.started += instance.OnPrimary;
            @Primary.performed += instance.OnPrimary;
            @Primary.canceled += instance.OnPrimary;
            @Secondary.started += instance.OnSecondary;
            @Secondary.performed += instance.OnSecondary;
            @Secondary.canceled += instance.OnSecondary;
            @HealthPotion.started += instance.OnHealthPotion;
            @HealthPotion.performed += instance.OnHealthPotion;
            @HealthPotion.canceled += instance.OnHealthPotion;
            @ManaPotion.started += instance.OnManaPotion;
            @ManaPotion.performed += instance.OnManaPotion;
            @ManaPotion.canceled += instance.OnManaPotion;
            @Ability1.started += instance.OnAbility1;
            @Ability1.performed += instance.OnAbility1;
            @Ability1.canceled += instance.OnAbility1;
            @Ability2.started += instance.OnAbility2;
            @Ability2.performed += instance.OnAbility2;
            @Ability2.canceled += instance.OnAbility2;
            @Ability3.started += instance.OnAbility3;
            @Ability3.performed += instance.OnAbility3;
            @Ability3.canceled += instance.OnAbility3;
            @Ability4.started += instance.OnAbility4;
            @Ability4.performed += instance.OnAbility4;
            @Ability4.canceled += instance.OnAbility4;
            @Ability5.started += instance.OnAbility5;
            @Ability5.performed += instance.OnAbility5;
            @Ability5.canceled += instance.OnAbility5;
            @Potion.started += instance.OnPotion;
            @Potion.performed += instance.OnPotion;
            @Potion.canceled += instance.OnPotion;
            @ForceMove.started += instance.OnForceMove;
            @ForceMove.performed += instance.OnForceMove;
            @ForceMove.canceled += instance.OnForceMove;
            @ForceStill.started += instance.OnForceStill;
            @ForceStill.performed += instance.OnForceStill;
            @ForceStill.canceled += instance.OnForceStill;
            @Menu.started += instance.OnMenu;
            @Menu.performed += instance.OnMenu;
            @Menu.canceled += instance.OnMenu;
            @Inventory.started += instance.OnInventory;
            @Inventory.performed += instance.OnInventory;
            @Inventory.canceled += instance.OnInventory;
            @Skills.started += instance.OnSkills;
            @Skills.performed += instance.OnSkills;
            @Skills.canceled += instance.OnSkills;
            @ExpandMap.started += instance.OnExpandMap;
            @ExpandMap.performed += instance.OnExpandMap;
            @ExpandMap.canceled += instance.OnExpandMap;
            @AbsorbAbility.started += instance.OnAbsorbAbility;
            @AbsorbAbility.performed += instance.OnAbsorbAbility;
            @AbsorbAbility.canceled += instance.OnAbsorbAbility;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Primary.started -= instance.OnPrimary;
            @Primary.performed -= instance.OnPrimary;
            @Primary.canceled -= instance.OnPrimary;
            @Secondary.started -= instance.OnSecondary;
            @Secondary.performed -= instance.OnSecondary;
            @Secondary.canceled -= instance.OnSecondary;
            @HealthPotion.started -= instance.OnHealthPotion;
            @HealthPotion.performed -= instance.OnHealthPotion;
            @HealthPotion.canceled -= instance.OnHealthPotion;
            @ManaPotion.started -= instance.OnManaPotion;
            @ManaPotion.performed -= instance.OnManaPotion;
            @ManaPotion.canceled -= instance.OnManaPotion;
            @Ability1.started -= instance.OnAbility1;
            @Ability1.performed -= instance.OnAbility1;
            @Ability1.canceled -= instance.OnAbility1;
            @Ability2.started -= instance.OnAbility2;
            @Ability2.performed -= instance.OnAbility2;
            @Ability2.canceled -= instance.OnAbility2;
            @Ability3.started -= instance.OnAbility3;
            @Ability3.performed -= instance.OnAbility3;
            @Ability3.canceled -= instance.OnAbility3;
            @Ability4.started -= instance.OnAbility4;
            @Ability4.performed -= instance.OnAbility4;
            @Ability4.canceled -= instance.OnAbility4;
            @Ability5.started -= instance.OnAbility5;
            @Ability5.performed -= instance.OnAbility5;
            @Ability5.canceled -= instance.OnAbility5;
            @Potion.started -= instance.OnPotion;
            @Potion.performed -= instance.OnPotion;
            @Potion.canceled -= instance.OnPotion;
            @ForceMove.started -= instance.OnForceMove;
            @ForceMove.performed -= instance.OnForceMove;
            @ForceMove.canceled -= instance.OnForceMove;
            @ForceStill.started -= instance.OnForceStill;
            @ForceStill.performed -= instance.OnForceStill;
            @ForceStill.canceled -= instance.OnForceStill;
            @Menu.started -= instance.OnMenu;
            @Menu.performed -= instance.OnMenu;
            @Menu.canceled -= instance.OnMenu;
            @Inventory.started -= instance.OnInventory;
            @Inventory.performed -= instance.OnInventory;
            @Inventory.canceled -= instance.OnInventory;
            @Skills.started -= instance.OnSkills;
            @Skills.performed -= instance.OnSkills;
            @Skills.canceled -= instance.OnSkills;
            @ExpandMap.started -= instance.OnExpandMap;
            @ExpandMap.performed -= instance.OnExpandMap;
            @ExpandMap.canceled -= instance.OnExpandMap;
            @AbsorbAbility.started -= instance.OnAbsorbAbility;
            @AbsorbAbility.performed -= instance.OnAbsorbAbility;
            @AbsorbAbility.canceled -= instance.OnAbsorbAbility;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Dialogue
    private readonly InputActionMap m_Dialogue;
    private List<IDialogueActions> m_DialogueActionsCallbackInterfaces = new List<IDialogueActions>();
    private readonly InputAction m_Dialogue_Primary;
    private readonly InputAction m_Dialogue_Secondary;
    private readonly InputAction m_Dialogue_Menu;
    public struct DialogueActions
    {
        private @VampireGame m_Wrapper;
        public DialogueActions(@VampireGame wrapper) { m_Wrapper = wrapper; }
        public InputAction @Primary => m_Wrapper.m_Dialogue_Primary;
        public InputAction @Secondary => m_Wrapper.m_Dialogue_Secondary;
        public InputAction @Menu => m_Wrapper.m_Dialogue_Menu;
        public InputActionMap Get() { return m_Wrapper.m_Dialogue; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogueActions set) { return set.Get(); }
        public void AddCallbacks(IDialogueActions instance)
        {
            if (instance == null || m_Wrapper.m_DialogueActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DialogueActionsCallbackInterfaces.Add(instance);
            @Primary.started += instance.OnPrimary;
            @Primary.performed += instance.OnPrimary;
            @Primary.canceled += instance.OnPrimary;
            @Secondary.started += instance.OnSecondary;
            @Secondary.performed += instance.OnSecondary;
            @Secondary.canceled += instance.OnSecondary;
            @Menu.started += instance.OnMenu;
            @Menu.performed += instance.OnMenu;
            @Menu.canceled += instance.OnMenu;
        }

        private void UnregisterCallbacks(IDialogueActions instance)
        {
            @Primary.started -= instance.OnPrimary;
            @Primary.performed -= instance.OnPrimary;
            @Primary.canceled -= instance.OnPrimary;
            @Secondary.started -= instance.OnSecondary;
            @Secondary.performed -= instance.OnSecondary;
            @Secondary.canceled -= instance.OnSecondary;
            @Menu.started -= instance.OnMenu;
            @Menu.performed -= instance.OnMenu;
            @Menu.canceled -= instance.OnMenu;
        }

        public void RemoveCallbacks(IDialogueActions instance)
        {
            if (m_Wrapper.m_DialogueActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDialogueActions instance)
        {
            foreach (var item in m_Wrapper.m_DialogueActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DialogueActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DialogueActions @Dialogue => new DialogueActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnPrimary(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
        void OnHealthPotion(InputAction.CallbackContext context);
        void OnManaPotion(InputAction.CallbackContext context);
        void OnAbility1(InputAction.CallbackContext context);
        void OnAbility2(InputAction.CallbackContext context);
        void OnAbility3(InputAction.CallbackContext context);
        void OnAbility4(InputAction.CallbackContext context);
        void OnAbility5(InputAction.CallbackContext context);
        void OnPotion(InputAction.CallbackContext context);
        void OnForceMove(InputAction.CallbackContext context);
        void OnForceStill(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnSkills(InputAction.CallbackContext context);
        void OnExpandMap(InputAction.CallbackContext context);
        void OnAbsorbAbility(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IDialogueActions
    {
        void OnPrimary(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
    }
}
