using Assets.Scripts.Gameflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities.Editor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class LivesUI : MonoBehaviour
    {
        [SerializeField]
        private Level level;

        [SerializeField]
        private Text livesDisplayText;

        private void Start()
        {
            level.OnLivesChanged += HandleLivesValueChanged;
        }

        private void OnDestroy()
        {
            level.OnLivesChanged -= HandleLivesValueChanged;
        }

        private void HandleLivesValueChanged(Level level)
        {
            updateUI = true;
        }


        private bool updateUI = true;

        private void Update()
        {
            if (!updateUI)
            {
                return;
            }

            livesDisplayText.text = level.CurrentLifes.ToString();

            updateUI = false;
        }
    }
}
