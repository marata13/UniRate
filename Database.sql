PGDMP     *    :                {           UniRate    14.0    14.0 ;    L           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            M           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            N           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            O           1262    66836    UniRate    DATABASE     d   CREATE DATABASE "UniRate" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Greek_Greece.1253';
    DROP DATABASE "UniRate";
                postgres    false            �            1259    75000 	   DepRating    TABLE     �  CREATE TABLE public."DepRating" (
    "Id" uuid NOT NULL,
    "DifficultyRating" integer,
    "ProfessorsRating" integer,
    "SubjectsRating" integer,
    "FreshnessRating" integer,
    "OrganisationRating" integer,
    "OverallRating" integer,
    "Review" text,
    "DateTime" timestamp with time zone,
    "DepartmentId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL,
    "UserId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL
);
    DROP TABLE public."DepRating";
       public         heap    postgres    false            �            1259    75007 
   Department    TABLE     �  CREATE TABLE public."Department" (
    "Id" uuid NOT NULL,
    "School" text,
    "Name" text,
    "EntranceGrade" integer,
    "StudyDuration" integer,
    "Directions" text,
    "SubjectCount" integer,
    "SiteUrl" text,
    "Phone" text,
    "Address" text,
    "Email" text,
    "LocationUrl" text,
    "UniversityId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL
);
     DROP TABLE public."Department";
       public         heap    postgres    false            �            1259    75013    FavoriteDepartment    TABLE     �   CREATE TABLE public."FavoriteDepartment" (
    "Id" uuid NOT NULL,
    "DepartmentId" uuid NOT NULL,
    "UserId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL
);
 (   DROP TABLE public."FavoriteDepartment";
       public         heap    postgres    false            �            1259    75017    FavoriteUniversity    TABLE     �   CREATE TABLE public."FavoriteUniversity" (
    "Id" uuid NOT NULL,
    "UniversityId" uuid NOT NULL,
    "UserId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL
);
 (   DROP TABLE public."FavoriteUniversity";
       public         heap    postgres    false            �            1259    75021 	   Professor    TABLE     �   CREATE TABLE public."Professor" (
    "Id" uuid NOT NULL,
    "Name" text,
    "Level" text,
    "Office" text,
    "Phone" text,
    "Email" text,
    "DepartmentId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL
);
    DROP TABLE public."Professor";
       public         heap    postgres    false            �            1259    75027    Subject    TABLE     
  CREATE TABLE public."Subject" (
    "Id" uuid NOT NULL,
    "Title" text,
    "Semester" text,
    "Type" text,
    "Hours" text,
    "SubjectUrl" text,
    "DepartmentId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL,
    "ProfessorId" uuid
);
    DROP TABLE public."Subject";
       public         heap    postgres    false            �            1259    75033 	   UniRating    TABLE     �  CREATE TABLE public."UniRating" (
    "Id" uuid NOT NULL,
    "SchoolRating" integer,
    "ActionsRating" integer,
    "Locationrating" integer,
    "AccessabilityRating" integer,
    "OrganisationRating" integer,
    "OverallRating" double precision,
    "Review" text,
    "DateTime" timestamp with time zone,
    "UniversityId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL,
    "UserId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL
);
    DROP TABLE public."UniRating";
       public         heap    postgres    false            �            1259    75040 
   University    TABLE       CREATE TABLE public."University" (
    "Id" uuid NOT NULL,
    "Name" text,
    "LogoUrl" text,
    "BackroundPhotoUrl" text,
    "Dean" text,
    "Location" text,
    "Address" text,
    "SiteUrl" text,
    "LocationUrl" text,
    "Phone" text,
    "ContactUrl" text
);
     DROP TABLE public."University";
       public         heap    postgres    false            �            1259    75045    User    TABLE     �   CREATE TABLE public."User" (
    "Id" uuid NOT NULL,
    "UserName" text,
    "Password" text,
    "Email" text,
    "Salt" bytea
);
    DROP TABLE public."User";
       public         heap    postgres    false            �            1259    75050    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    postgres    false            @          0    75000 	   DepRating 
   TABLE DATA           �   COPY public."DepRating" ("Id", "DifficultyRating", "ProfessorsRating", "SubjectsRating", "FreshnessRating", "OrganisationRating", "OverallRating", "Review", "DateTime", "DepartmentId", "UserId") FROM stdin;
    public          postgres    false    209   fQ       A          0    75007 
   Department 
   TABLE DATA           �   COPY public."Department" ("Id", "School", "Name", "EntranceGrade", "StudyDuration", "Directions", "SubjectCount", "SiteUrl", "Phone", "Address", "Email", "LocationUrl", "UniversityId") FROM stdin;
    public          postgres    false    210   ZV       B          0    75013    FavoriteDepartment 
   TABLE DATA           N   COPY public."FavoriteDepartment" ("Id", "DepartmentId", "UserId") FROM stdin;
    public          postgres    false    211   JZ       C          0    75017    FavoriteUniversity 
   TABLE DATA           N   COPY public."FavoriteUniversity" ("Id", "UniversityId", "UserId") FROM stdin;
    public          postgres    false    212   �[       D          0    75021 	   Professor 
   TABLE DATA           h   COPY public."Professor" ("Id", "Name", "Level", "Office", "Phone", "Email", "DepartmentId") FROM stdin;
    public          postgres    false    213   �\       E          0    75027    Subject 
   TABLE DATA           |   COPY public."Subject" ("Id", "Title", "Semester", "Type", "Hours", "SubjectUrl", "DepartmentId", "ProfessorId") FROM stdin;
    public          postgres    false    214   c       F          0    75033 	   UniRating 
   TABLE DATA           �   COPY public."UniRating" ("Id", "SchoolRating", "ActionsRating", "Locationrating", "AccessabilityRating", "OrganisationRating", "OverallRating", "Review", "DateTime", "UniversityId", "UserId") FROM stdin;
    public          postgres    false    215   `l       G          0    75040 
   University 
   TABLE DATA           �   COPY public."University" ("Id", "Name", "LogoUrl", "BackroundPhotoUrl", "Dean", "Location", "Address", "SiteUrl", "LocationUrl", "Phone", "ContactUrl") FROM stdin;
    public          postgres    false    216   r       H          0    75045    User 
   TABLE DATA           O   COPY public."User" ("Id", "UserName", "Password", "Email", "Salt") FROM stdin;
    public          postgres    false    217   &z       I          0    75050    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          postgres    false    218   �{       �           2606    75054    DepRating PK_DepRating 
   CONSTRAINT     Z   ALTER TABLE ONLY public."DepRating"
    ADD CONSTRAINT "PK_DepRating" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."DepRating" DROP CONSTRAINT "PK_DepRating";
       public            postgres    false    209            �           2606    75056    Department PK_Department 
   CONSTRAINT     \   ALTER TABLE ONLY public."Department"
    ADD CONSTRAINT "PK_Department" PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY public."Department" DROP CONSTRAINT "PK_Department";
       public            postgres    false    210            �           2606    75058 (   FavoriteDepartment PK_FavoriteDepartment 
   CONSTRAINT     l   ALTER TABLE ONLY public."FavoriteDepartment"
    ADD CONSTRAINT "PK_FavoriteDepartment" PRIMARY KEY ("Id");
 V   ALTER TABLE ONLY public."FavoriteDepartment" DROP CONSTRAINT "PK_FavoriteDepartment";
       public            postgres    false    211            �           2606    75060 (   FavoriteUniversity PK_FavoriteUniversity 
   CONSTRAINT     l   ALTER TABLE ONLY public."FavoriteUniversity"
    ADD CONSTRAINT "PK_FavoriteUniversity" PRIMARY KEY ("Id");
 V   ALTER TABLE ONLY public."FavoriteUniversity" DROP CONSTRAINT "PK_FavoriteUniversity";
       public            postgres    false    212            �           2606    75062    Professor PK_Professor 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Professor"
    ADD CONSTRAINT "PK_Professor" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."Professor" DROP CONSTRAINT "PK_Professor";
       public            postgres    false    213            �           2606    75064    Subject PK_Subject 
   CONSTRAINT     V   ALTER TABLE ONLY public."Subject"
    ADD CONSTRAINT "PK_Subject" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Subject" DROP CONSTRAINT "PK_Subject";
       public            postgres    false    214            �           2606    75066    UniRating PK_UniRating 
   CONSTRAINT     Z   ALTER TABLE ONLY public."UniRating"
    ADD CONSTRAINT "PK_UniRating" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."UniRating" DROP CONSTRAINT "PK_UniRating";
       public            postgres    false    215            �           2606    75068    University PK_University 
   CONSTRAINT     \   ALTER TABLE ONLY public."University"
    ADD CONSTRAINT "PK_University" PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY public."University" DROP CONSTRAINT "PK_University";
       public            postgres    false    216            �           2606    75070    User PK_User 
   CONSTRAINT     P   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "PK_User" PRIMARY KEY ("Id");
 :   ALTER TABLE ONLY public."User" DROP CONSTRAINT "PK_User";
       public            postgres    false    217            �           2606    75072 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            postgres    false    218            �           1259    75073    IX_DepRating_DepartmentId    INDEX     ]   CREATE INDEX "IX_DepRating_DepartmentId" ON public."DepRating" USING btree ("DepartmentId");
 /   DROP INDEX public."IX_DepRating_DepartmentId";
       public            postgres    false    209            �           1259    75074    IX_DepRating_UserId    INDEX     Q   CREATE INDEX "IX_DepRating_UserId" ON public."DepRating" USING btree ("UserId");
 )   DROP INDEX public."IX_DepRating_UserId";
       public            postgres    false    209            �           1259    75075    IX_Department_UniversityId    INDEX     _   CREATE INDEX "IX_Department_UniversityId" ON public."Department" USING btree ("UniversityId");
 0   DROP INDEX public."IX_Department_UniversityId";
       public            postgres    false    210            �           1259    75076 "   IX_FavoriteDepartment_DepartmentId    INDEX     o   CREATE INDEX "IX_FavoriteDepartment_DepartmentId" ON public."FavoriteDepartment" USING btree ("DepartmentId");
 8   DROP INDEX public."IX_FavoriteDepartment_DepartmentId";
       public            postgres    false    211            �           1259    75077    IX_FavoriteDepartment_UserId    INDEX     c   CREATE INDEX "IX_FavoriteDepartment_UserId" ON public."FavoriteDepartment" USING btree ("UserId");
 2   DROP INDEX public."IX_FavoriteDepartment_UserId";
       public            postgres    false    211            �           1259    75078 "   IX_FavoriteUniversity_UniversityId    INDEX     o   CREATE INDEX "IX_FavoriteUniversity_UniversityId" ON public."FavoriteUniversity" USING btree ("UniversityId");
 8   DROP INDEX public."IX_FavoriteUniversity_UniversityId";
       public            postgres    false    212            �           1259    75079    IX_FavoriteUniversity_UserId    INDEX     c   CREATE INDEX "IX_FavoriteUniversity_UserId" ON public."FavoriteUniversity" USING btree ("UserId");
 2   DROP INDEX public."IX_FavoriteUniversity_UserId";
       public            postgres    false    212            �           1259    75080    IX_Professor_DepartmentId    INDEX     ]   CREATE INDEX "IX_Professor_DepartmentId" ON public."Professor" USING btree ("DepartmentId");
 /   DROP INDEX public."IX_Professor_DepartmentId";
       public            postgres    false    213            �           1259    75081    IX_Subject_DepartmentId    INDEX     Y   CREATE INDEX "IX_Subject_DepartmentId" ON public."Subject" USING btree ("DepartmentId");
 -   DROP INDEX public."IX_Subject_DepartmentId";
       public            postgres    false    214            �           1259    75082    IX_Subject_ProfessorId    INDEX     W   CREATE INDEX "IX_Subject_ProfessorId" ON public."Subject" USING btree ("ProfessorId");
 ,   DROP INDEX public."IX_Subject_ProfessorId";
       public            postgres    false    214            �           1259    75083    IX_UniRating_UniversityId    INDEX     ]   CREATE INDEX "IX_UniRating_UniversityId" ON public."UniRating" USING btree ("UniversityId");
 /   DROP INDEX public."IX_UniRating_UniversityId";
       public            postgres    false    215            �           1259    75084    IX_UniRating_UserId    INDEX     Q   CREATE INDEX "IX_UniRating_UserId" ON public."UniRating" USING btree ("UserId");
 )   DROP INDEX public."IX_UniRating_UserId";
       public            postgres    false    215            �           1259    75085    IX_User_UserName    INDEX     R   CREATE UNIQUE INDEX "IX_User_UserName" ON public."User" USING btree ("UserName");
 &   DROP INDEX public."IX_User_UserName";
       public            postgres    false    217            �           2606    75086 .   DepRating FK_DepRating_Department_DepartmentId    FK CONSTRAINT     �   ALTER TABLE ONLY public."DepRating"
    ADD CONSTRAINT "FK_DepRating_Department_DepartmentId" FOREIGN KEY ("DepartmentId") REFERENCES public."Department"("Id") ON DELETE CASCADE;
 \   ALTER TABLE ONLY public."DepRating" DROP CONSTRAINT "FK_DepRating_Department_DepartmentId";
       public          postgres    false    209    3214    210            �           2606    75091 "   DepRating FK_DepRating_User_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."DepRating"
    ADD CONSTRAINT "FK_DepRating_User_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") ON DELETE CASCADE;
 P   ALTER TABLE ONLY public."DepRating" DROP CONSTRAINT "FK_DepRating_User_UserId";
       public          postgres    false    3238    217    209            �           2606    75096 0   Department FK_Department_University_UniversityId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Department"
    ADD CONSTRAINT "FK_Department_University_UniversityId" FOREIGN KEY ("UniversityId") REFERENCES public."University"("Id") ON DELETE CASCADE;
 ^   ALTER TABLE ONLY public."Department" DROP CONSTRAINT "FK_Department_University_UniversityId";
       public          postgres    false    216    210    3235            �           2606    75101 @   FavoriteDepartment FK_FavoriteDepartment_Department_DepartmentId    FK CONSTRAINT     �   ALTER TABLE ONLY public."FavoriteDepartment"
    ADD CONSTRAINT "FK_FavoriteDepartment_Department_DepartmentId" FOREIGN KEY ("DepartmentId") REFERENCES public."Department"("Id") ON DELETE CASCADE;
 n   ALTER TABLE ONLY public."FavoriteDepartment" DROP CONSTRAINT "FK_FavoriteDepartment_Department_DepartmentId";
       public          postgres    false    211    210    3214            �           2606    75106 4   FavoriteDepartment FK_FavoriteDepartment_User_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."FavoriteDepartment"
    ADD CONSTRAINT "FK_FavoriteDepartment_User_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") ON DELETE CASCADE;
 b   ALTER TABLE ONLY public."FavoriteDepartment" DROP CONSTRAINT "FK_FavoriteDepartment_User_UserId";
       public          postgres    false    211    217    3238            �           2606    75111 @   FavoriteUniversity FK_FavoriteUniversity_University_UniversityId    FK CONSTRAINT     �   ALTER TABLE ONLY public."FavoriteUniversity"
    ADD CONSTRAINT "FK_FavoriteUniversity_University_UniversityId" FOREIGN KEY ("UniversityId") REFERENCES public."University"("Id") ON DELETE CASCADE;
 n   ALTER TABLE ONLY public."FavoriteUniversity" DROP CONSTRAINT "FK_FavoriteUniversity_University_UniversityId";
       public          postgres    false    212    216    3235            �           2606    75116 4   FavoriteUniversity FK_FavoriteUniversity_User_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."FavoriteUniversity"
    ADD CONSTRAINT "FK_FavoriteUniversity_User_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") ON DELETE CASCADE;
 b   ALTER TABLE ONLY public."FavoriteUniversity" DROP CONSTRAINT "FK_FavoriteUniversity_User_UserId";
       public          postgres    false    3238    212    217            �           2606    75121 .   Professor FK_Professor_Department_DepartmentId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Professor"
    ADD CONSTRAINT "FK_Professor_Department_DepartmentId" FOREIGN KEY ("DepartmentId") REFERENCES public."Department"("Id") ON DELETE CASCADE;
 \   ALTER TABLE ONLY public."Professor" DROP CONSTRAINT "FK_Professor_Department_DepartmentId";
       public          postgres    false    213    210    3214            �           2606    75126 *   Subject FK_Subject_Department_DepartmentId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Subject"
    ADD CONSTRAINT "FK_Subject_Department_DepartmentId" FOREIGN KEY ("DepartmentId") REFERENCES public."Department"("Id") ON DELETE CASCADE;
 X   ALTER TABLE ONLY public."Subject" DROP CONSTRAINT "FK_Subject_Department_DepartmentId";
       public          postgres    false    210    214    3214            �           2606    75131 (   Subject FK_Subject_Professor_ProfessorId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Subject"
    ADD CONSTRAINT "FK_Subject_Professor_ProfessorId" FOREIGN KEY ("ProfessorId") REFERENCES public."Professor"("Id");
 V   ALTER TABLE ONLY public."Subject" DROP CONSTRAINT "FK_Subject_Professor_ProfessorId";
       public          postgres    false    214    3225    213            �           2606    75136 .   UniRating FK_UniRating_University_UniversityId    FK CONSTRAINT     �   ALTER TABLE ONLY public."UniRating"
    ADD CONSTRAINT "FK_UniRating_University_UniversityId" FOREIGN KEY ("UniversityId") REFERENCES public."University"("Id") ON DELETE CASCADE;
 \   ALTER TABLE ONLY public."UniRating" DROP CONSTRAINT "FK_UniRating_University_UniversityId";
       public          postgres    false    3235    215    216            �           2606    75141 "   UniRating FK_UniRating_User_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."UniRating"
    ADD CONSTRAINT "FK_UniRating_User_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") ON DELETE CASCADE;
 P   ALTER TABLE ONLY public."UniRating" DROP CONSTRAINT "FK_UniRating_User_UserId";
       public          postgres    false    3238    215    217            @   �  x��V�n7]�_�]j��o���@?�r���dÒ�z��v� N�ͮ@��Rv�ڂ"?�?��R�%'�� ��F��O�ǹ�/L�,U�3*eh�ס�SN�Z0�횺��?✴GqoI{�>�+���n���xoH�,��Y�2�!)��,.Q`F�U����޷��w���� ��gb"�,��@�Q���h�u��KTC���-�ǽ�����M��%�_�l��x���Q�={+�-�U{
��)h�A�<şc�`��Sg�	�=F./�9G.`�!�s��:�UV�z ��'�C���;�i�������M�\�)OasՅ�`����ăp�B�P��#n~�?������Hs<0�����X{�[��Д)�l���R=�<�b��P�JzZVJP	C���ZaK��R:�֔׎7MIk[**)��Q#��*-mPj]2����r�2�@��e�T�ђ+�&S
��oe�?*C�]{�kOz�E ܤD��i`�=�F�X�q��iO����;�i{Ծ���!���*�==��g�R���}�UGؾ��)a؃;�#�B�k�KWY�}����A�����u]Yg�:º
�Fp�J'�B����H�o.�R��d<�l�zo8�'��˄l7d�$����h2=&nT���N�IZF��x���#�U=qc�C%ُ,�@���n}�B�9��Q7SE1�$Ϟ���������Qv '��O�#���V�Oށ3ɫq��~+�d062tO����P��у�]:� ��K�W�g8g��tHS	xMӁJ^x�l�imL���2U-���������JVijkQR��2ua\(Ϸtt�P}�{�J`6���ep���]CAmi���W�(Y<,���N� +h�ԕƅ*׈�4F����F|�����<�����W0	r�Ƿ����o�[�i$�> |�� ��q�m��}�K��3�#v� �O�<a�,���%4>H�:���2Ϧ�,<@ڪ}��t�]zc��e�����̣;G�p:c�z�|�����A3L�t��Qw���,�b,�<G;�y��,' �w�|�� ��} O[ݠ��i�S��_֓�OكK�.,T��y�(�5����M��)}Y3+��a�t��n�,�P�U�j���,�������W�W���x�x7G��awIu4mMc~�ÆC'�u7גh����9RS�}�c�ϡ�,�BaL�)Qڒi�$����o������a1������/����      A   �  x��VOoE?�?��@O{����E�JQ�r��������N,�%�O$iR!�"$�@�H�T���|�ٯě�:؍#��
!"yfw�����~�7�i�C��y"$-�"Z�Tp�BƳȿ��⩿���o~R|�/��'�<+v�eq�c�O�kR�������������-u��?�	���#&%M"��l8�-Gu�sqP�O�����^�lR���ߠ2.��K���kѿ�����>�(-��2�8,��?h�Yƫ�T<�mUHs���RН�r:Z��?|�����n����͍�F�3hmlZ�����u���]׍8���S�����ƽW/��JR����ct�Wהh�yc,�!@��L'�~w�]>�`�u!���V���V����Ö�g���ݘ���I��
��@���S-cn�hJH%�BI�pb��B5S`ThJy"�y0Ц1�!���F9�6��1��h�r�dC�� c�8��ļ'��#E&47@��L�G��Y�rg+����+��3|��8'��S�l��[y�J��U]7��� �Ϙ� ��K!�d^��5��Ժ� ���M�5NH�&,˒�\�-ɘt�gH�)'V)�i;W��wE�_Q�pʙ���P~��E��a)J����s��M�%���g�Z!�����Uꍑ-��x<5ٸ�%��U
S��8�\ ���Ό)\${vtY�o�����f��6�3R	�)�$�KU;��X%@�C��Z�7�Pr��9-�����.� !�8~UR�42���u��T��r�\�@������q�TJE�S�@q`�Ib0'�S:W�D�;leִۘl����wo�;7��i;e
����o�r	�+���o�b��,������D��I�ǻmSέH���6�s�2�00 BQ���b�eZ����X�颬���s�GD���y�}nzT�U��,�h�ȿ���]N������;��ƿ��6k�ڟ� C�      B   2  x���A� 1��w1O���̆��a�z�?EQ:K��k�Up��q��8�q��O���	,�`�lڞ�����XN�MҶ Op�tf��n-����?��h{��u�50I|Ù*�	�]g?X�#��uٴ^]nKK�S��b �:�(O��0"�`uW{���f�o89#��Zf��v-q��Э�q��3�R+��L�����u�$Ñ�E����!��Z�v�^Gh��>��6n�4��N�m�!��%�q��k�1��L�=cl�g�l����ml��R��I�e��8W�hķW��y��iߪ�      C   4  x�����$0C��^�cc0��%`���6q�'!�kn_	��!��3Y0d����:��r�i��dȨs��v��u�6H5j:�X�d+_�b�ފk,o���"��	�^��DO��S�uD:�S���,�r6�߬<\�G�CD��#��=�yZ�SV��
^��g�x��̟��Ng���n.��}q�b�ύ#�W`�ͦT�@��}_�>~?��&�a���=��[&���?���+�)�p���re��j�i�:�f�np.�{�$���L_���ɞ\�k�����oU����~��H�      D   1  x��W�nG]7_�>)T��.�M=ab�yvNx		�$ʃ(�@J4�`�q�=��S=FA0�Rd�5S]�}O�{�=���y��l��X�UN$_4U�:C���~�����_���oO������~�?���N��;�!�}�����?�{~���~���R'(��t����\{��y��ӌ��3\fT2�%W��d����F�љ�۝�9�(qQ	"���jk��	���ܟb�+[� �RF�	�89��FY�9�w�#��)b��k���+�x�u齠~Ǐ���~;�[��cG���h\w1o��i<mɝ!1Ig�H�8���[t�#����#����^�ǀ���� 1,�q��ش����"�ۘ�ٴ�E!}�Y3�����HIQ���Sʭt��..��.n��X�/�^\*�s�ss`�qHw��,n���`��$��/q�eb��N�nR���Z���/�d"r�$E\	�i=�X�� ���C�ā�!�~�D�V�]�8���}��2�??�n����L����d1�X�<��(.��L��Żo!��@�.�8z��N�������y7F%���/�辚��ʑ�K}&FA�$r�8�"��8�����!���P�k�);\J�zp����n2ڀލ�!q�xV�('��FT�$jB	�j�����y:��UDu {K1�6�4[ n�D=�k����G���p��z ׆sz�ѝ�8��M��K���=�VC�J$h�Ri!;���	;P�=�P��<�A6?���/�m�����Nx�:A��K�SoHִ� �����DM��oW������Yۚ�.n�Va�6���&�eT�F�Y��Lh�6��0���bo��W�@x��%-�&E�p�.Mǳ��x��	'u�*��愅ː��B��y�P�`�Y�������Mj�i^���%�U�U��]����f���[a�cM=W��~/��C���d�j�|`��� ��>���˥���Z��Χff
O�}���(��aSd*ó0�vԝ!�+P�å���}�Έ��%?Og��{���S�iձ�0�c(ޫ�Cm��Nj��V���
Ax�Y[���b_8?:�
!2_��D�Q)�&NYK�-Ȳ����.�w��d�8\��!��K���l:�[��5�A*�Oep(��Dg.�G�p-�c�p�G���](���4>�R-^n�l�H�aD%�K��T
�3F�O(�ԙKeL���/+������<?:�(j�G���6/���6��U�r0��*��n� seUv�b��^�j�Dl���ݥX%����"��ڈ�/M}���Va������;F� 4��+�y�Mui�(��e���y���#S몦I?�t3>O�i�۠ bYZ"+k�
�/E�	����`�@���W~�cG��J������h��]�����f��2RAb��$y0Ԕ���<ءh�>i�����5�.�<k�#dE� �#��Y3a9<�X[]�Z5�v?e�i�d�� �1�\8���46l҅aS�#zw���Y�G�q�1H��J�VMpl}����\�F_�9u�Կ0���      E   ?	  x��Z�n�}n����m8�K>$O#E� E��x�؀F$�2L���!ʃ9�1<�տ�u��-;nc"�ۑե��ӵ�Y{��)!��&�RL[��p��0�KQ�Q�r�>�?�;��&��t�ۙ>��v;�n�{1�^t?w�ݧn�;�&����n7�>İ�鷸��0}4�~춺W#5���__�'����k�~u�Ɲ;w��[���k7����7��ߗ[7��n	&�op���rW�J*�OZ��A�3Β��K��
"�X�FTiIIy�(�)�P��yˮ	ϋ-B��3ɘ�K/ �Td����|н�v���#�����޸��K�n�;����`f��!��|���_�Ÿ�;N&����op~�).�����Q�:c&�C�Y������n6���;ʹ�8i��� h�Lp<�~��'����y���Z���⧖0�\��$`�,����e'R5�i٨{}�_e{�}����SP��Gs���O`�|fY\HfY����9)�E�8I��t�U�è{>���f�n!��+5��b��|l�zoi�V"K�-��^����ʵ{8���܊����ǆ�^b�+FFJ*R1+
�`8�A���3�EI������������.�j.��R��RI���[d�D.�0�)�zw�WUk�#2�wU�[�5
2���*~%ضT���i���47h���w8�L{����y-�R��K��c�e-ڜ������cO�N�͔�>�lO7[^[-����9"�Kp�y���KY�Ƅ���p�G}b}��q�x��#s.��Z4c�`�a��3,=n1
�,֟�NMx���n�{�0�3���k���ۘ=���&s"�[������[�_,V�K�r��8A�AC�R/��$sB$Q��3�p!�p���a&p�����v�
�4W��'P�^����K�U�D�h�6����T��%n~���G� �IϾ'�n��%��?��:1�3d���c�;�w��=���1	��|p�F��v1j\����d�<Ėy0���,bP���fd�����\�qf�=�+K5P�&!�0����[�s:�3ʃ����6ľ6�,]A�T�rM��_JZ�)kG��j2:�!�69�2�Y3"!�>������?��K�M5�`�|�B@Ǻ Eרb#h#e�����P��f��Jq�a8j�D�[�`j59!2�6!��h�>]��bρ'}����Ґ(����SN��[ ��h�J,��� =���5ݺ���,�Py*T��r<���L�\P�Zf�.f��S/���k��xE����e�1��T��6[=;,���޷�]����S�S����Pt���$�C�n4�<0h�w#��_p��/twf�~��EQ�j0))2�"��R(VVIk���F�]F���l��5�4��g�se*\a��L�1�i
T�/d=�i.]���@.�j_�3p��e�"��Hˈ�1���X^٬.�u�o����k�G�loƳ1���iֽ����Yy	j�A�J�[H��y��/�m�Lj���g��Y�򯡋0�\�F[�5��e�*�T)�M| Tk�<�9'��ye���Vl�����j{�����$Xֳ�cP�(�1,����t�������
��ێ:���5��,ł:7#��̢��7��5y��zs��z����dM����nO�)g򑡞�){͋�Z�Z��4������Q�Bgiɠb��"s��0�
�d��^:k��)�uή��Xr�h�Xb� [1�rE��	�<y���%�V����h�CM���a�����
ɐ1I�U��ŀ@ZRSZ1#�9[�}+�����s���\w]������B�9�3J��e1BNZ*����4��lh�lo�M�M�A̎�M���97�w0���GW���6XÕ�o2�[/"9��DиPP(6l���ك��ֽx�}�q�=��'�����2N������eD��2�R��\j* �8�ci^j�>��ق=�����^M�T\ۚ�2m�j��pkB��k�^����*�0�U���95+�N�=��l���Y��PWF[O	�U��J aQo�,�J~����LCt��I�+)KB}�Ϝ��!��jLr��s:���*�������K)ۋ]p�
�P}.&s.�魓/���+��B� ��M?�����B2M�2���gʅ�.̓K|�C��mT�M���Q��ֹ
J�����I݈�����yR��˃YϸA���5>�T���5����P�5�$%� n�����_�̘�y��q��k�w��,�T��IVd,*�0PC,�Xx
!���`��f�Qe�7lZJ��W⏛��R�����k������      F   �  x��;o�F�k�Sl�"Zbߏk�R�L�Omy yR��c#A��H�2EZ�p ������Y����T��8���������e���^bK�"P��k��%�E>���D������B���f���j�lQܬV[4��G�e4.Z�u;��)rmD�v��4��u7��o+t���ȧ��c�L��ƻ>^�!��&nC���$d8A�K�Z�i��y� Ǯ{�:uM��st��z��M�����#�����x�0�BG�0���T"�B/��6�Я?�\��=�6��e�%�>qE��΁~^9����X�E;�(�<f#�0I�㘢�B�\�����*�IY;b����o�ǂ���m��zX�;eୖn��>�R��M*�X���V~;kX`dB��ڙ�Ckw���6��fԸm�+������f(_��9 ���uh���q���]�r�>��oƺk���I�(����n�(�����/�[�>�|����;) �6��~t�;iO�2�g(���e���*v0J�ac΁�X�`0����dLNZ��u�AN�XX	�)z�������Q��jw(o�R؊3n�.(E�j������;(Y0ҋ�d"�0��͜`I��<) O
��Ɛ ���ѹ�=� O���!L�`���B2,0����@0��aa�ǆ�����L+��I���j�M� S�����qG�Z�Cyc��TBH*��<�)*�I�@)����v�z����!�sN�H@�����!�g!�'tFX��;�7GiDV�[CdAɽw9��m�JF8-17*x��(K�(���)�<&��By�](<�&�����P¯��^��f &#���&�H8dk�{ 12�p̄��%-�Xε��$րJ��0�"��dMdL�#�L��k ��k�����+�E���1__�؝��)/x�@���=��z܂�gP�or��t����*�N��ۇi^�ͪ��'��QǃnU�ϻ>��D�k�]
gp�ԧ��?>5u:+�|����+���e�I:)@��PX��X``-�:������)�l�۬2'�ђ�k��D�L9CX��d� YI+���Nx��Hd����S�[-�Е�e��.RYdJ��R�%�íU��5��e�O�{)��ᖛ�k��D��fc�����xo�*q�)�@�&j|u�p���"3Vq%)e�1�eeE(!�m3��'c`=S��\%8!�	c�s�@�o����ݓ���~ϧ����m��cz5}�^�~��~1}�w���@���L^N�7���|�s�f�WF^L�w���Wxr�{��izS�~��������L�߫��/�%L���Ώ�q�����S�@�E��?��0����4���ez�/��?kD/��#��{V��:>>�*��Q      G     x�͗[o��ǟ�O!=�O%9�K��p�l]��ݢ
Cr(1�D��|�Ssi[lڢ�b��C_rAx���7��Rό$o����y)�D�y���������q���$`��@e)��R�5�������y1�m�r�`��y���yټiA�8u�_6���u=�~E��0ix���C��&,�^���(���FE�������Q��Wl�G��kTC3�l�è����lD�b�!�{k�Wp�O�����xv���k�{��D�}�����g��j�3^Ào��k͗a�����1,�x�>k��~�R�4����p2��y�+#��-�Lw�(z�y�.��c��d����X��@C�8����̕�J(�E�����#���
%H��T��a�8G�S�e��d�M�K�w�1"�Mr)T�e����8�W�C��c��Xq�ޠ��Z�&VY�&�6�N�nu�D�i���ގ�S�����i9�Lѽ�#z����r��v��v�Cw~��)v�/��q��E`��I�+�l�C�s&X��ݻF0b���z�v����`<���`��RQ��@"dF9�tI�x�������_5o��7�W��[����H8�}ќ��c�����Ll�J�IY�*��vh���M�c�nL��|e����*�anj33�Q����E{u^慿B��{ 3<�s8�z8!J��W:P�>��wN�[�S8x~�sX2,�x��y6��9iI�2��S�B"��T2�1�ZR�4�R0�$c�5d	�hM�6$I�I���S�U��� %�%�㮣WL�ng(^�,���=��Ŵ�ө�a������0������G,'Ũ6I]c�N7V����)
�b�ŒH!�kͿ����_x�/����4���G��WZ��Цw��q�noG�B�+V�#���	~����ĸ��d�����.��A���d�����܋��V����{�� ��BȎʗ��O�#����t���'���3�\��1�R{�����`:�E�I,�"\FJ�CgjA��2!ш3����I�ij����Li$4ORi���kpD:}j�`gʶ:ud��JZ/a��l�Ż��9�]����(+��In�U�"�ҦB(�,`���C0K �8N8O@��ryD���	���I��N"�2m~��vwh�ѻ�y���p`!�2�Q�pm&u? *𗠢_C��-�wྀ<�t�d��ُ|f���������٘�����
I��fD�P)P�'P�:�I��d(�)�r
�3

�c	>�}]�UY�(��$�Ï����iB�H��^��w{�)��)��S&B�M�Ҁl;�nc���c*��娳���ݞ��r������L��Y�d������P�$Z��&����:�c�%"4,*`F� �]���,�!
��0� ��>n��K�$�:>u`8�����dG"i�q��]{C�v˷ڷ�7om��]?�?��)�[:���ɲ�t�-?m�|{�O8�����[w��؜��V��H!4>��=�i}��&�Ѝ�����"?�+�#x�߀Z@�{˯9���1�̭�uvo���i�)�E�ar����T"C��`���/�
/��˺DI� spBb��I2��)N��^�Lf�DG�P�x]������'EЁ�%������NU}� a��)s}N��V���?:�E��'Lک>�<���u��u�&p
�\�7���&�������M�t=
*[��]�ښ�0��P�$:��� �!)�.�۫���U�D$����N
Ӎ����GC!�����`;��!I-R�ώޗ:�_��h�iv/����(F�-lg���=aƄ+Je	 �]����$��k��G$�Bk,��`6$�3l����PͧIB,�,5,]����G��*HZ�C���X����J�%�r���-We:��$�<sj���&�CNa��J��*!��t�P��S�/�Ǽ/��;.�*6U�P�fpz����6΅A];2Sg��.�v\���E�Cӵ���wS�h�7������S      H   �  x�E�InAE��]ڨ�\;w}
ojL[��@��V6Y��'?���I���6,�F�p�0��8���M������Y�.5ʎ�\ b�KI�G+h��A���A8
�H.�Y��{�� �!HB��#�P�d1%+����i��H;��q:%�$�ģ���}��_>~����������t1�F(:	a� ]͂b��O�^�Xg^�F��kZ��7>G� ?x��_Y��d��p��z�5�K%��g@���J�!nmTڨv�ZskmL�r ����n���E]�sCĥ�w.��Pv��9�h�0~���ɝ�"{9��=+g�3�ӌ%bV�
p����ɕ"g.�\L��=���?��qbljԔ�`�uԓ��L�Sg��W`WMH�h����n�6��o���B�p:ͅ��8�
[�8Ɇ�Jo���j���A�׷������K      I   �   x�]��
!��u���^SkF�*�����6Ɉ�9�}D���� @	-����}�-br����v��>d%a��oB��é����k̬4��]"�1�|��k���z�i+�4��a��b�Gla�)�S��2^ҷ��1�^��0�     