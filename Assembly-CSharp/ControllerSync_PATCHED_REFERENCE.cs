    // Token: 0x060049CF RID: 18895
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
            if (localPlayer != null)
            {
                EntityPlayer entityPlayer = (EntityPlayer)localPlayer.GetEntity();
                if (entityPlayer != null)
                {
                    if (entityPlayer.vmethod_25().PlayerState_0 != PlayerInfoSync.PlayerState.Spawned)
                    {
                        return;
                    }
                    InstanceInput instanceInput = entityPlayer.GetComponent<InstanceInput>();
                    InputFrame[] array;
                    instanceInput.FlushOutgoingInputs(out array);
                    stream.SendNext(entityPlayer.transform.position);
                    stream.SendNext(instanceInput.currentInput.m_flags);
                    stream.SendNext(instanceInput.currentInput.m_yaw);
                    stream.SendNext(instanceInput.currentInput.m_pitch);
                    return;
                }
            }
        }
        else if (MonoSingleton<Session>.Instance != null)
        {
            // Unchanged — this build never reads real peer ControllerSync
            // data client-side (the server no longer relays it at all, see
            // the Go server's opRaiseEvent filter), so this branch stays
            // dead code in practice. Left untouched intentionally.
            PhotonPlayer sender = info.sender;
            if (sender != null)
            {
                PlayerInfoSync playerInfoSync = MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(sender.ActorId);
                if (playerInfoSync)
                {
                    Entity entity = playerInfoSync.GetEntity();
                    if (entity)
                    {
                        InstanceInput component = entity.GetComponent<InstanceInput>();
                        if (component != null)
                        {
                            byte[] array2 = (byte[])stream.ReceiveNext();
                            InputFrame[] array3;
                            this.Deserialize(array2, out array3);
                            StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
                            if (currentSession != null)
                            {
                                StatisticsManager.StatSheet personalStatSheet = currentSession.GetPersonalStatSheet(playerInfoSync);
                                if (personalStatSheet != null)
                                {
                                    personalStatSheet.SetPingQuality(NetworkManager.GetPingById(sender.ActorId));
                                }
                            }
                            if (array3.Length != 0)
                            {
                                component.EnqueueIncomingInputs(array3);
                            }
                        }
                    }
                }
            }
        }
    }
