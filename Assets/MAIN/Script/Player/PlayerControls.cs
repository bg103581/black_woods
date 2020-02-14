// GENERATED AUTOMATICALLY FROM 'Assets/MAIN/Script/Player/PlayerControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e688d954-2a84-4a80-9711-48031c5da66b"",
            ""actions"": [
                {
                    ""name"": ""DotsMovement"",
                    ""type"": ""Value"",
                    ""id"": ""4ab2cba0-d636-404c-a573-5daea48ed6ef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DotsJump"",
                    ""type"": ""Button"",
                    ""id"": ""bec104b7-5830-4cb4-9a52-10d24f36991d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StrixMovement"",
                    ""type"": ""Value"",
                    ""id"": ""8d7854cc-6c9f-4cd5-9f03-f2f8d25cbc11"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StrixJump"",
                    ""type"": ""Button"",
                    ""id"": ""5999d7ec-2bd9-4e95-97f9-f5ba7bc5402e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DotsBec"",
                    ""type"": ""Value"",
                    ""id"": ""51c6bf55-b238-4a1b-99c4-17b1da7d107a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StrixFlair"",
                    ""type"": ""Button"",
                    ""id"": ""0e1d8f47-a3de-4728-9581-3f22f502145b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StrixCreuse"",
                    ""type"": ""Button"",
                    ""id"": ""1c65a57c-a070-4a9e-b7c9-6979d3fbb684"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StrixCoop"",
                    ""type"": ""Value"",
                    ""id"": ""641d285e-eb90-4da1-a6a2-6e723615413a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DotsCoop"",
                    ""type"": ""Button"",
                    ""id"": ""1f51afda-3f09-476f-8dd7-f47321c75f5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StrixCatch"",
                    ""type"": ""Button"",
                    ""id"": ""80e3f559-69b7-4363-94b7-b2446d05c712"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""DotsChante"",
                    ""type"": ""Button"",
                    ""id"": ""9926f89d-26ca-4c9c-88d3-d8f42b9c4cbf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1b53dde7-8194-4962-99ed-11a10267146a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DotsJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81b5567a-7c77-453e-ac7b-aed6075e9294"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DotsJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e8f9eb3-afe1-4ab4-8e10-24fb5b18edbc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdce4177-d36d-4331-b2c7-06310f013d1c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StrixJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""right/left"",
                    ""id"": ""f9ec39fc-325a-447c-8e67-c1d8d5ea9a2d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DotsMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a7cf89e2-b481-4532-97cd-5f027996fdc8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DotsMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""92fad2fe-0251-46ad-927c-69bd2934b69d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DotsMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cb8d7fda-9860-4e7f-a688-cbaa34c9105c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DotsMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""834fb603-81de-4b27-ac54-40c4a9bda3de"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DotsMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fbea5f54-9452-4d45-bbbc-85a438574ba7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DotsMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""right/left"",
                    ""id"": ""bbf764d9-d21e-4ae6-8465-b87a149f4bb5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StrixMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2cbd7a69-61c4-44df-90db-fe2d038072be"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""201b272a-ee73-464c-a798-8920fa85ea00"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e43f1e3d-bc1c-4828-aa76-3556477a0df4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8f54b5ed-c6c6-493f-895c-7b4effec337e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7f23c7c4-c3c3-4e34-a10f-f8fb4fa4eb17"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StrixMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f77cabd0-deb9-4784-99a3-b2338522907e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DotsBec"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d865b4fb-3448-4750-ba89-497862b02ba2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DotsBec"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57111f60-2f2f-48ea-a176-cd37c2a1d2b6"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StrixFlair"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa3d12da-a969-4a70-874a-21b894cb94e0"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixFlair"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b6b6cf7-8be5-41d2-9b68-fa38bd6501d6"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StrixCreuse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f06506e8-1d89-4a61-86d6-520094917d3e"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixCreuse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""138696be-79ad-4c5a-a42b-2f938c07864d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StrixCoop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73672f5c-a39d-4c2a-bba4-c609e64aa0d4"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixCoop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7218fffd-a8e9-4194-badb-4ed20e1f521f"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DotsCoop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a41d149-f6b4-4643-85ef-43ab2962080f"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DotsCoop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f45e444-2b2a-46a9-85e1-a3fd702c3805"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixCatch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8b617bb-f83a-4dc3-aaf7-dbc623fe58a0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StrixCatch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""711885db-b6a5-4fc4-8204-bbc6c7ca3032"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DotsChante"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51cf5c54-e037-47a9-9190-e03b0130244d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DotsChante"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""d80dbb7e-5f35-4cb3-b5a3-d2192f5f763b"",
            ""actions"": [
                {
                    ""name"": ""PopupAide"",
                    ""type"": ""Button"",
                    ""id"": ""f548c73a-5b04-4f4c-94ee-abebcbd92d5d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b3b3b68c-45c1-4847-bdc1-6721ab4eaf1b"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PopupAide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_DotsMovement = m_Player.FindAction("DotsMovement", throwIfNotFound: true);
        m_Player_DotsJump = m_Player.FindAction("DotsJump", throwIfNotFound: true);
        m_Player_StrixMovement = m_Player.FindAction("StrixMovement", throwIfNotFound: true);
        m_Player_StrixJump = m_Player.FindAction("StrixJump", throwIfNotFound: true);
        m_Player_DotsBec = m_Player.FindAction("DotsBec", throwIfNotFound: true);
        m_Player_StrixFlair = m_Player.FindAction("StrixFlair", throwIfNotFound: true);
        m_Player_StrixCreuse = m_Player.FindAction("StrixCreuse", throwIfNotFound: true);
        m_Player_StrixCoop = m_Player.FindAction("StrixCoop", throwIfNotFound: true);
        m_Player_DotsCoop = m_Player.FindAction("DotsCoop", throwIfNotFound: true);
        m_Player_StrixCatch = m_Player.FindAction("StrixCatch", throwIfNotFound: true);
        m_Player_DotsChante = m_Player.FindAction("DotsChante", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_PopupAide = m_Menu.FindAction("PopupAide", throwIfNotFound: true);
    }

    ~PlayerControls()
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_DotsMovement;
    private readonly InputAction m_Player_DotsJump;
    private readonly InputAction m_Player_StrixMovement;
    private readonly InputAction m_Player_StrixJump;
    private readonly InputAction m_Player_DotsBec;
    private readonly InputAction m_Player_StrixFlair;
    private readonly InputAction m_Player_StrixCreuse;
    private readonly InputAction m_Player_StrixCoop;
    private readonly InputAction m_Player_DotsCoop;
    private readonly InputAction m_Player_StrixCatch;
    private readonly InputAction m_Player_DotsChante;
    public struct PlayerActions
    {
        private PlayerControls m_Wrapper;
        public PlayerActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @DotsMovement => m_Wrapper.m_Player_DotsMovement;
        public InputAction @DotsJump => m_Wrapper.m_Player_DotsJump;
        public InputAction @StrixMovement => m_Wrapper.m_Player_StrixMovement;
        public InputAction @StrixJump => m_Wrapper.m_Player_StrixJump;
        public InputAction @DotsBec => m_Wrapper.m_Player_DotsBec;
        public InputAction @StrixFlair => m_Wrapper.m_Player_StrixFlair;
        public InputAction @StrixCreuse => m_Wrapper.m_Player_StrixCreuse;
        public InputAction @StrixCoop => m_Wrapper.m_Player_StrixCoop;
        public InputAction @DotsCoop => m_Wrapper.m_Player_DotsCoop;
        public InputAction @StrixCatch => m_Wrapper.m_Player_StrixCatch;
        public InputAction @DotsChante => m_Wrapper.m_Player_DotsChante;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                DotsMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsMovement;
                DotsMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsMovement;
                DotsMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsMovement;
                DotsJump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsJump;
                DotsJump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsJump;
                DotsJump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsJump;
                StrixMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixMovement;
                StrixMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixMovement;
                StrixMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixMovement;
                StrixJump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixJump;
                StrixJump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixJump;
                StrixJump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixJump;
                DotsBec.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsBec;
                DotsBec.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsBec;
                DotsBec.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsBec;
                StrixFlair.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixFlair;
                StrixFlair.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixFlair;
                StrixFlair.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixFlair;
                StrixCreuse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixCreuse;
                StrixCreuse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixCreuse;
                StrixCreuse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixCreuse;
                StrixCoop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixCoop;
                StrixCoop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixCoop;
                StrixCoop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixCoop;
                DotsCoop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsCoop;
                DotsCoop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsCoop;
                DotsCoop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsCoop;
                StrixCatch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixCatch;
                StrixCatch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixCatch;
                StrixCatch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixCatch;
                DotsChante.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsChante;
                DotsChante.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsChante;
                DotsChante.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsChante;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                DotsMovement.started += instance.OnDotsMovement;
                DotsMovement.performed += instance.OnDotsMovement;
                DotsMovement.canceled += instance.OnDotsMovement;
                DotsJump.started += instance.OnDotsJump;
                DotsJump.performed += instance.OnDotsJump;
                DotsJump.canceled += instance.OnDotsJump;
                StrixMovement.started += instance.OnStrixMovement;
                StrixMovement.performed += instance.OnStrixMovement;
                StrixMovement.canceled += instance.OnStrixMovement;
                StrixJump.started += instance.OnStrixJump;
                StrixJump.performed += instance.OnStrixJump;
                StrixJump.canceled += instance.OnStrixJump;
                DotsBec.started += instance.OnDotsBec;
                DotsBec.performed += instance.OnDotsBec;
                DotsBec.canceled += instance.OnDotsBec;
                StrixFlair.started += instance.OnStrixFlair;
                StrixFlair.performed += instance.OnStrixFlair;
                StrixFlair.canceled += instance.OnStrixFlair;
                StrixCreuse.started += instance.OnStrixCreuse;
                StrixCreuse.performed += instance.OnStrixCreuse;
                StrixCreuse.canceled += instance.OnStrixCreuse;
                StrixCoop.started += instance.OnStrixCoop;
                StrixCoop.performed += instance.OnStrixCoop;
                StrixCoop.canceled += instance.OnStrixCoop;
                DotsCoop.started += instance.OnDotsCoop;
                DotsCoop.performed += instance.OnDotsCoop;
                DotsCoop.canceled += instance.OnDotsCoop;
                StrixCatch.started += instance.OnStrixCatch;
                StrixCatch.performed += instance.OnStrixCatch;
                StrixCatch.canceled += instance.OnStrixCatch;
                DotsChante.started += instance.OnDotsChante;
                DotsChante.performed += instance.OnDotsChante;
                DotsChante.canceled += instance.OnDotsChante;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_PopupAide;
    public struct MenuActions
    {
        private PlayerControls m_Wrapper;
        public MenuActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PopupAide => m_Wrapper.m_Menu_PopupAide;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                PopupAide.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnPopupAide;
                PopupAide.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnPopupAide;
                PopupAide.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnPopupAide;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                PopupAide.started += instance.OnPopupAide;
                PopupAide.performed += instance.OnPopupAide;
                PopupAide.canceled += instance.OnPopupAide;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnDotsMovement(InputAction.CallbackContext context);
        void OnDotsJump(InputAction.CallbackContext context);
        void OnStrixMovement(InputAction.CallbackContext context);
        void OnStrixJump(InputAction.CallbackContext context);
        void OnDotsBec(InputAction.CallbackContext context);
        void OnStrixFlair(InputAction.CallbackContext context);
        void OnStrixCreuse(InputAction.CallbackContext context);
        void OnStrixCoop(InputAction.CallbackContext context);
        void OnDotsCoop(InputAction.CallbackContext context);
        void OnStrixCatch(InputAction.CallbackContext context);
        void OnDotsChante(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnPopupAide(InputAction.CallbackContext context);
    }
}
