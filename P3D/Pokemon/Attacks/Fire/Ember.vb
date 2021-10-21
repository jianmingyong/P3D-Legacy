﻿Namespace BattleSystem.Moves.Fire

    Public Class Ember

        Inherits Attack

        Public Sub New()
            '#Definitions
            Me.Type = New Element(Element.Types.Fire)
            Me.ID = 52
            Me.OriginalPP = 25
            Me.CurrentPP = 25
            Me.MaxPP = 25
            Me.Power = 40
            Me.Accuracy = 100
            Me.Category = Categories.Special
            Me.ContestCategory = ContestCategories.Cute
            Me.Name = "Ember"
            Me.Description = "The target is attacked with small flames. It may also leave the target with a burn."
            Me.CriticalChance = 1
            Me.IsHMMove = False
            Me.Target = Targets.OneAdjacentTarget
            Me.Priority = 0
            Me.TimesToAttack = 1
            '#End

            '#SpecialDefinitions
            Me.MakesContact = False
            Me.ProtectAffected = True
            Me.MagicCoatAffected = False
            Me.SnatchAffected = False
            Me.MirrorMoveAffected = True
            Me.KingsrockAffected = False
            Me.CounterAffected = False

            Me.DisabledWhileGravity = False
            Me.UseEffectiveness = True
            Me.ImmunityAffected = True
            Me.HasSecondaryEffect = True
            Me.RemovesFrozen = False

            Me.IsHealingMove = False
            Me.IsRecoilMove = False
            Me.IsPunchingMove = False
            Me.IsDamagingMove = True
            Me.IsProtectMove = False
            Me.IsSoundMove = False

            Me.IsAffectedBySubstitute = True
            Me.IsOneHitKOMove = False
            Me.IsWonderGuardAffected = True
            '#End
            Me.AIField1 = AIField.Damage
            Me.AIField2 = AIField.CanBurn

            EffectChances.Add(10)
        End Sub

        Public Overrides Sub MoveHits(own As Boolean, BattleScreen As BattleScreen)
            Dim chance As Integer = GetEffectChance(0, own, BattleScreen)
            If Core.Random.Next(0, 100) < chance Then
                BattleScreen.Battle.InflictBurn(Not own, own, BattleScreen, "", "move:ember")
            End If
        End Sub

        Public Overrides Sub InternalUserPokemonMoveAnimation(ByVal BattleScreen As BattleScreen, ByVal own As Boolean, ByVal CurrentPokemon As Pokemon, ByVal CurrentEntity As NPC, ByVal CurrentModel As ModelEntity)
            Dim MoveAnimation As AnimationQueryObject = New AnimationQueryObject(CurrentEntity, own)
            Dim FireballEntity As Entity = MoveAnimation.SpawnEntity(New Vector3(0.0, 0.0, 0.0), TextureManager.GetTexture("Textures\Battle\Fire\FireBall"), New Vector3(0.5F), 1.0F)

            MoveAnimation.AnimationMove(FireballEntity, True, 2.0, 0.0, 0.0, 0.05, False, True, 0.0, 0.0,, -0.5, 0)
            MoveAnimation.AnimationPlaySound("Battle\Attacks\Fire\Ember_Start", 0, 0)
            For i = 0 To 12
                Dim SmokeEntity = MoveAnimation.SpawnEntity(New Vector3(CSng(i * 0.2), 0.0, 0.0), TextureManager.GetTexture("Textures\Battle\Fire\Smoke"), New Vector3(0.2), 1)
                MoveAnimation.AnimationFade(SmokeEntity, True, 0.02, False, 0.0, CSng(i * 0.2), 0.0)

                i += 1
            Next
            BattleScreen.BattleQuery.Add(MoveAnimation)
        End Sub

        Public Overrides Sub InternalOpponentPokemonMoveAnimation(ByVal BattleScreen As BattleScreen, ByVal own As Boolean, ByVal CurrentPokemon As Pokemon, ByVal CurrentEntity As NPC, ByVal CurrentModel As ModelEntity)
            Dim MoveAnimation As AnimationQueryObject = New AnimationQueryObject(CurrentEntity, own)
            Dim FireballEntity As Entity = MoveAnimation.SpawnEntity(New Vector3(2.0, 0.0, 0.0), TextureManager.GetTexture("Textures\Battle\Fire\FireBall"), New Vector3(0.5F), 1.0F)

            MoveAnimation.AnimationMove(FireballEntity, True, 0.0, 0.0, 0.0, 0.05, False, True, 0.0, 0.0,, -0.5, 0)

            For i = 0 To 12
                Dim SmokeEntity = MoveAnimation.SpawnEntity(New Vector3(CSng(3.0 - i * 0.2), 0.0, 0.0), TextureManager.GetTexture("Textures\Battle\Fire\Smoke"), New Vector3(0.2), 1)
                MoveAnimation.AnimationFade(SmokeEntity, True, 0.02, False, 0.0, CSng(i * 0.2), 0.0)

                i += 1
            Next
            MoveAnimation.AnimationPlaySound("Battle\Attacks\Fire\Ember_Hit", 2, 0)

            Dim FireEntity1 As Entity = MoveAnimation.SpawnEntity(New Vector3(-0.25, -0.25, -0.25), TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 0, 32, 32), ""), New Vector3(0.5F), 1, 1, 1)
            Dim FireEntity2 As Entity = MoveAnimation.SpawnEntity(New Vector3(0.25, -0.25, 0.25), TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 0, 32, 32), ""), New Vector3(0.5F), 1, 1, 1)
            Dim FireEntity3 As Entity = MoveAnimation.SpawnEntity(New Vector3(0.25, -0.25, -0.25), TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 0, 32, 32), ""), New Vector3(0.5F), 1, 1, 1)

            MoveAnimation.AnimationChangeTexture(FireEntity1, False, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 32, 32, 32)), 2, 1)
            MoveAnimation.AnimationChangeTexture(FireEntity2, False, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 32, 32, 32)), 2, 1)
            MoveAnimation.AnimationChangeTexture(FireEntity3, False, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 32, 32, 32)), 2, 1)

            MoveAnimation.AnimationChangeTexture(FireEntity1, False, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 64, 32, 32)), 3, 1)
            MoveAnimation.AnimationChangeTexture(FireEntity2, False, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 64, 32, 32)), 3, 1)
            MoveAnimation.AnimationChangeTexture(FireEntity3, False, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 64, 32, 32)), 3, 1)

            MoveAnimation.AnimationChangeTexture(FireEntity1, False, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 96, 32, 32)), 4, 1)
            MoveAnimation.AnimationChangeTexture(FireEntity2, False, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 96, 32, 32)), 4, 1)
            MoveAnimation.AnimationChangeTexture(FireEntity3, False, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 96, 32, 32)), 4, 1)

            MoveAnimation.AnimationChangeTexture(FireEntity1, True, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 128, 32, 32)), 5, 1)
            MoveAnimation.AnimationChangeTexture(FireEntity2, True, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 128, 32, 32)), 5, 1)
            MoveAnimation.AnimationChangeTexture(FireEntity3, True, TextureManager.GetTexture("Textures\Battle\Fire\Ember", New Rectangle(0, 128, 32, 32)), 5, 1)

            BattleScreen.BattleQuery.Add(MoveAnimation)
        End Sub
    End Class

End Namespace